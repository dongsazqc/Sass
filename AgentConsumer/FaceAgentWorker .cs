using AgentConsumer.Service;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using System.Threading;
using System.Threading.Tasks;

public class FaceAgentWorker : BackgroundService
{
    private IConnection _connection;
    private IModel _channel;

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        (_connection, _channel) = RabbitHelper.Connect();

        string queueName = "face_queue";
        FaceMesageListen.Listen(_channel, queueName);

        Console.WriteLine("[Worker] Agent đang lắng nghe queue...");
        return Task.CompletedTask;
    }

    public override void Dispose()
    {
        _channel?.Close();
        _connection?.Close();
        base.Dispose();
    }
}
