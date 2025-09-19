using RabbitMQ.Client;
using System;
using System.Text;
using Newtonsoft.Json;

class Program
{
    static void Main()
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        // --- Chọn message muốn gửi ---
        var addPersonMessage = new
        {
            @operator = "AddPerson",
            Ip = "192.168.0.12",
            Username = "admin",
            Password = "112233",
            DeviceID = 2565490,
            ResponseQueue = "add_person_response", // queue nhận kết quả
            info = new
            {
                DeviceID = 2565490,
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

        var searchPersonMessage = new
        {
            @operator = "SearchPersonList",
            Ip = "192.168.0.12",
            Username = "admin",
            Password = "112233",
            DeviceID = 2565490,
            ResponseQueue = "search_person_response", // queue nhận kết quả
            info = new
            {
                DeviceID = 2565490,
                PersonType = 0,
                BeginTime = "2000-01-01T00:00:00",
                EndTime = "2030-12-31T23:59:59"
            }
        };

        // --- Chọn gửi AddPerson hay SearchPersonList ---
        var messageToSend = addPersonMessage; // đổi sang addPersonMessage nếu muốn

        var json = JsonConvert.SerializeObject(messageToSend);
        var body = Encoding.UTF8.GetBytes(json);

        // --- Publish lên đúng exchange + routing key ---
        channel.BasicPublish(
            exchange: "face_exchange",          // phải trùng với worker
            routingKey: messageToSend.@operator, // trùng với routing key bind trong worker
            basicProperties: null,
            body: body
        );

        Console.WriteLine("Đã gửi message lên exchange: " + json);
    }
}
