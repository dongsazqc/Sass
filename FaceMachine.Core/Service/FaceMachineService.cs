using FaceMachine.Core.Helpers;
using FaceMachine.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceMachine.Core.Service
{
    public class FaceMachineService
    {
        private readonly FaceApiClient_FaceRecognitionTerminal _client;

        public FaceMachineService()
        {
            _client = new FaceApiClient_FaceRecognitionTerminal();
        }

        public async Task<bool> AddPersonToMachine(int machineId, Person_FaceRecognitonTerminal person)
        {
            // Lấy info máy từ mapping
            var machine = MachineMapping.GetMachine(machineId); // IP, username, password, deviceID

            // Gọi FaceApiClient với đủ tham số
            var result = await _client.AddPersonAsync(
                machine.Ip,
                machine.Username,
                machine.Password,
                person,
                machine.DeviceID
            );

            return result.Contains("success");
        }



    }

}
