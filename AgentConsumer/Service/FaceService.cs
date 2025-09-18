using AgentConsumer.Models;
using FaceMachine.Core.Helpers;
using FaceMachine.Core.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

namespace AgentConsumer.Service
{
    public static class FaceService
    {
        public static async Task HandleAddPerson(JObject json)
        {
            try
            {
                // Lấy mấy trường cần thiết từ JSON
                string ip = json["Ip"]?.ToString();
                string username = json["Username"]?.ToString();
                string password = json["Password"]?.ToString();
                int deviceId = json["DeviceID"]?.ToObject<int>() ?? 0;

                // Parse info ra Person model
                var person = json["Info"]?.ToObject<Person_FaceRecognitonTerminal>();

                if (string.IsNullOrEmpty(ip) || person == null)
                {
                    Console.WriteLine("[Error] JSON thiếu dữ liệu bắt buộc!");
                    return;
                }

                // Gọi API
                var api = new FaceApiClient_FaceRecognitionTerminal(); // cái class có AddPersonAsync
                var result = await api.AddPersonAsync(ip, username, password, person, deviceId);

                Console.WriteLine($"[API Response] {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Error] HandleAddPerson failed: {ex.Message}");
            }
        }
    }
}
