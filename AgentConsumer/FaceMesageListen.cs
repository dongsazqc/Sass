using AgentConsumer.Service;
using Newtonsoft.Json.Linq;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading.Tasks;

public static class FaceMesageListen
{
    /// <summary>
    /// Listener cho từng queue
    /// </summary>
    public static void Listen(IModel channel, string queueName, Func<JObject, Task> handler)
    {
        channel.QueueDeclare(queue: queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += async (model, ea) =>
        {
            var body = Encoding.UTF8.GetString(ea.Body.ToArray());
            Console.WriteLine($"[Debug] Nhận JSON từ queue {queueName}: {body}");

            try
            {
                var json = JObject.Parse(body);

                // Chạy handler tương ứng
                await handler(json);

                channel.BasicAck(ea.DeliveryTag, false);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[Error] Lỗi xử lý message: " + ex.Message);
            }
        };

        channel.BasicConsume(queue: queueName, autoAck: false, consumer: consumer);
    }
}
