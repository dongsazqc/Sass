using AgentConsumer.Models;
using FaceMachine.Core.Helpers;
using FaceMachine.Core.Models;
using Newtonsoft.Json.Linq;
using RabbitMQ.Client;
using System;
using System.Text;
using System.Threading.Tasks;

namespace AgentConsumer.Service
{

    /// <summary>
    /// Class này là nơi sử lí các tín hiệu đường truyền lên(check điều kiện và là  nơi trả dữ liệu)
    /// </summary>
    public static class FaceService_FaceRecognitionTerminal
    {
        public static async Task HandleAddPerson(JObject json)
        {
            try
            {
                string ip = json["Ip"]?.ToString();
                string username = json["Username"]?.ToString();
                string password = json["Password"]?.ToString();
                int deviceId = json["DeviceID"]?.ToObject<int>() ?? 0;

                var person = json["info"]?.ToObject<Person_FaceRecognitonTerminal>();

                if (string.IsNullOrEmpty(ip) || person == null)
                {
                    Console.WriteLine("[Error] JSON thiếu dữ liệu bắt buộc!");
                    return;
                }

                var api = new FaceApiClient_FaceRecognitionTerminal();
                var result = await api.AddPersonAsync(ip, username, password, person, deviceId);



                // Bắn ngược kết quả về RabbitMQ
                var connectionFactory = new RabbitMQ.Client.ConnectionFactory() { HostName = "localhost" };
                using var connection = connectionFactory.CreateConnection();
                using var channel = connection.CreateModel();

                string responseQueue = json["ResponseQueue"]?.ToString() ?? "default_response_queue";
                channel.QueueDeclare(responseQueue, durable: true, exclusive: false, autoDelete: false);

                var responseBody = Encoding.UTF8.GetBytes(result ?? "No result");
                channel.BasicPublish(exchange: "",
                                     routingKey: responseQueue,
                                     basicProperties: null,
                                     body: responseBody);

                Console.WriteLine($"[API Response sent to queue '{responseQueue}'] {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Error] HandleAddPerson failed: {ex.Message}");
            }
        }

        public static async Task HandleListPerson(JObject json)
        {
            try
            {
                // Lấy mấy trường cần thiết từ JSON
                string ip = json["Ip"]?.ToString();
                string username = json["Username"]?.ToString();
                string password = json["Password"]?.ToString();
                int deviceId = json["DeviceID"]?.ToObject<int>() ?? 0;

                var listperson = json["info"]?.ToObject<ListPerson_FaceRecognitonTerminal>();
                if (string.IsNullOrEmpty(ip) || listperson == null)
                {
                    Console.WriteLine("[Error] JSON thiếu dữ liệu bắt buộc!");
                    return;
                }

                // Gọi API
                var api = new FaceApiClient_FaceRecognitionTerminal();
                var result = await api.ListPersonAsync(ip, username, password, listperson, deviceId);

                // Bắn ngược kết quả về RabbitMQ
                var connectionFactory = new RabbitMQ.Client.ConnectionFactory() { HostName = "localhost" };
                using var connection = connectionFactory.CreateConnection();
                using var channel = connection.CreateModel();

                string responseQueue = json["ResponseQueue"]?.ToString() ?? "default_response_queue";
                channel.QueueDeclare(responseQueue, durable: true, exclusive: false, autoDelete: false);

                string responseMessage = string.IsNullOrWhiteSpace(result)
                    ? "[Warn] Không có ai trong danh sách"
                    : result;

                var responseBody = Encoding.UTF8.GetBytes(responseMessage);
                channel.BasicPublish(exchange: "",
                                     routingKey: responseQueue,
                                     basicProperties: null,
                                     body: responseBody);

                Console.WriteLine($"[API Response sent to queue '{responseQueue}'] {responseMessage}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Error] HandleListPerson failed: {ex.Message}");
            }
        }

    }
}
