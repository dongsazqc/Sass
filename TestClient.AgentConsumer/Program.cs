using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;

class Program
{
    static void Main()
    {
        // Tạo message cực gọn
        var message = new FaceMessage
        {

            Operator = "AddPerson",
            DeviceID = 2565490,
            Ip = "192.168.0.12",
            PersonType = 0,
            Name = "Pham Van Dong",
            Gender = 1,
            Nation = 23,
            CardType = 0,
            IdCard = "100",
            Birthday = new DateTime(1990, 11, 04),
            Telnum = "18888888888",
            Native = "",
            Address = "thanh hoa",
            Notes = "dai ca"
        };

        // Kết nối RabbitMQ và gửi message
        var factory = new ConnectionFactory()
        {
            HostName = "localhost",
            Port = 5672,
            UserName = "guest",
            Password = "guest"
        };

        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        string queueName = "face_queue";
        channel.QueueDeclare(queue: queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);

        var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
        channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: body);

        Console.WriteLine("✅ Đã gửi lệnh AddPerson lên RabbitMQ!");
        Console.ReadLine();
    }
}

// --- Class message cực gọn ---
public class FaceMessage
{
    public string Operator { get; set; }
    public string Ip { get; set; }

    public int PersonType { get; set; }
    public int DeviceID { get; set; }
    public string Name { get; set; }
    public int Gender { get; set; }
    public int Nation { get; set; }
    public int CardType { get; set; }
    public string IdCard { get; set; }
    public DateTime Birthday { get; set; }
    public string Telnum { get; set; }
    public string Native { get; set; }
    public string Address { get; set; }
    public string Notes { get; set; }
}
