using AgentConsumer.Service;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using System;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Worker chạy nền, giữ agent luôn lắng nghe queue
/// </summary>
public class FaceAgentWorker : BackgroundService
{
    private IConnection _connection; // Kết nối tới RabbitMQ
    private IModel _channel;         // Channel để gửi/nhận message

    /// <summary>
    /// Hàm chính chạy khi host start, agent bắt đầu lắng nghe
    /// </summary>
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // 1️⃣ Kết nối RabbitMQ
        (_connection, _channel) = RabbitHelper.Connect();

        // 2️⃣ Tạo exchange kiểu direct
        // Exchange kiểu direct sẽ route message theo đúng routing key
        _channel.ExchangeDeclare("face_exchange", "direct", durable: true);

        // 3️⃣ Tạo queue cho chức năng AddPerson và bind routing key
        _channel.QueueDeclare("add_person_queue", durable: true, exclusive: false, autoDelete: false);
        _channel.QueueBind("add_person_queue", "face_exchange", "AddPerson");

        // 4️⃣ Tạo queue cho chức năng SearchPersonList và bind routing key
        _channel.QueueDeclare("search_person_queue", durable: true, exclusive: false, autoDelete: false);
        _channel.QueueBind("search_person_queue", "face_exchange", "SearchPersonList");


        // tạo queue cho chức năng chụp ảnh
        _channel.QueueDeclare("capture_image_queue", durable: true, exclusive: false, autoDelete: false);
        _channel.QueueBind("capture_image_queue", "face_exchange", "FrontalFaceSnap");

        // 5️⃣ Lắng nghe từng queue
        // Khi có message tới, tự động gọi handler tương ứng
        FaceMesageListen.Listen(_channel, "add_person_queue", FaceService_FaceRecognitionTerminal.HandleAddPerson);
        FaceMesageListen.Listen(_channel, "search_person_queue", FaceService_FaceRecognitionTerminal.HandleListPerson);


        FaceMesageListen.Listen(_channel, "capture_image_queue", FaceService_FaceRecognitionTerminal.HandleFrontalFaceSnap);
        // 6️⃣ Log ra console biết worker đang chạy
        Console.WriteLine("[Worker] Agent đang chạy và lắng nghe các queue...");

        // Task.CompletedTask nghĩa là ExecuteAsync kết thúc **nhưng listener vẫn chạy nền**
        return Task.CompletedTask;
    }

    /// <summary>
    /// Khi app tắt, cleanup kết nối/channel
    /// </summary>
    public override void Dispose()
    {
        _channel?.Close();     // Đóng channel
        _connection?.Close();  // Đóng kết nối
        base.Dispose();
    }
}
