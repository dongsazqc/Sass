using FaceGetWeb_Api.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FaceGetWeb_Api.HelperWeb
{

    public class HttpClientHelper<T>
    {
        private readonly string baseUrl = "https://api-nextcrm-v3.nextcrm.vn/api/time-attendance-machine/time-attendance-machine";
        private readonly string token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJodHRwOlwvXC9hcGktbmV4dGNybS12My5uZXh0Y3JtLnZuXC9hcGlcL2F1dGhcL2xvZ2luIiwiaWF0IjoxNzU4NTMxNDgxLCJleHAiOjE3NTg2MTc4ODEsIm5iZiI6MTc1ODUzMTQ4MSwianRpIjoib0xrUFZEZUpPcmh5aGlVTSIsInN1YiI6MjEsInBydiI6Ijk0ZGJkOTYxYWFlZjBlM2NlNjZhZDdkNTBlNjQ3NzE3NjA5ZGRhMjQiLCJ0ZW5hbnRfaWQiOjEsImFwcF90eXBlIjoiZ3ltIiwidXNlcl90eXBlIjoibm9ybWFsIn0.dtrOcLPuH4qniMAwhv0pVNuek_beM70EC4yDT1BQXHc";

        private readonly HttpClient client;

        public HttpClientHelper()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        // ---- Method lấy password dựa trên IP ----
        public async Task<string> GetAsync(string endpoint, string ip)
        {
            var response = await client.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<TimeAttendanceResponse>(json);

            var machine = data.Data.FirstOrDefault(m => m.Ip == ip);
            return machine?.Password; // trả null nếu không tìm thấy
        }
    }
}