using FaceMachine.Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceMachine.Core.Helpers
{
    // Core/Helpers/FaceApiClient.cs
    public class FaceApiClient_FaceRecognitionTerminal
    {
        private readonly HttpClient _client;
        private readonly HelpersDevice _helperDevice;
        public FaceApiClient_FaceRecognitionTerminal()
        {
            _client = new HttpClient();
            _helperDevice = new HelpersDevice();
        }



        public async Task<string> AddPersonAsync(string ip, string username, string password, Person_FaceRecognitonTerminal person, string deviceId)
        {
            person.DeviceID = deviceId;


            var url = $"http://{ip}/action/AddPerson";
            var payload = new FaceRequest_FaceRecognitionTerminal
            {
                @operator = "AddPerson",
                info = person
            };
            var checkPayload = JsonConvert.SerializeObject(payload, Formatting.Indented);
            Console.WriteLine("Payload chuẩn bị gửi:");
            Console.WriteLine(checkPayload);


            return await _helperDevice.PostAsync(url, payload, username, password);
        }
        public async Task<string>ListPersonAsync( string ip , string username , string password, ListPerson_FaceRecognitonTerminal listperson, string deviceId)
        {
            listperson.DeviceID = deviceId;
            var url = $"http://{ip}/action/SearchPersonList";
            var payload = new FaceRequest_FaceRecognitionTerminal
            {
                @operator = "SearchPersonList",
                info = listperson
            };

           
            return await _helperDevice.PostAsync(url, payload, username, password);


        }

        public async Task<string> FrontalFaceSnapAsync(string ip, string username, string password, FrontalFaceSnap_FaceRecognitionTerminal fronta, string deviceId)
        {
            var url = $"http://{ip}/action/FrontalFaceSnap";
            var payload = new FaceRequest_FaceRecognitionTerminal
            {
                @operator = "FrontalFaceSnap",
                info = fronta

            };
            return await _helperDevice.PostAsync(url, payload, username, password);
        }

    }

}
