using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;

class Program
{
    static void Main()
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        string queueName = "face_queue";
        channel.QueueDeclare(queue: queueName,
                             durable: true,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);



        // Message JSON gửi lên agent consumer
        var message = new
        {
            Operator = "AddPerson",
            Ip = "192.168.0.12",
            Username = "admin",
            Password = "112233",
            DeviceID = 2565490,
            Info = new
            {
                Name = "Pham Van Dong",
                Gender = 0,
                Nation = 0,
                CardType = 0,
                IdCard = "1",
                Birthday = new DateTime(1990, 11, 04),
                Telnum = "18888888888",
                Native = "",
                Address = "thanh hoa",
                Notes = "dep trai nhat thanh hoa",
                PersonType = 0
            }
        };

        var json = JsonConvert.SerializeObject(message);
        var body = Encoding.UTF8.GetBytes(json);

        channel.BasicPublish(exchange: "",
                             routingKey: queueName,
                             basicProperties: null,
                             body: body);

        Console.WriteLine("Đã gửi message lên queue: " + json);
    }
}
