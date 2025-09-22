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
        // ==== FIX CỨNG ====
        private readonly string baseUrl = "https://api-nextcrm-v3.nextcrm.vn/api/time-attendance-machine/time-attendance-machine?pageLimit=15&page=1&strSearch=&search[refer_code]=&search[name]=";
        private readonly string token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJodHRwOlwvXC9hcGktbmV4dGNybS12My5uZXh0Y3JtLnZuXC9hcGlcL2F1dGhcL2xvZ2luIiwiaWF0IjoxNzU4NTMxNDgxLCJleHAiOjE3NTg2MTc4ODEsIm5iZiI6MTc1ODUzMTQ4MSwianRpIjoib0xrUFZEZUpPcmh5aGlVTSIsInN1YiI6MjEsInBydiI6Ijk0ZGJkOTYxYWFlZjBlM2NlNjZhZDdkNTBlNjQ3NzE3NjA5ZGRhMjQiLCJ0ZW5hbnRfaWQiOjEsImFwcF90eXBlIjoiZ3ltIiwidXNlcl90eXBlIjoibm9ybWFsIn0.dtrOcLPuH4qniMAwhv0pVNuek_beM70EC4yDT1BQXHc";

        private readonly HttpClient client;

        public HttpClientHelper()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Chỉ dùng Bearer token
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<T> GetAsync(string endpoint)
        {
            try
            {
                var response = await client.GetAsync(endpoint);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                throw new Exception("GET request failed: " + ex.Message);
            }
        }

        public async Task<T> PostAsync(string endpoint, object data)
        {
            try
            {
                var jsonData = JsonConvert.SerializeObject(data);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(endpoint, content);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                throw new Exception("POST request failed: " + ex.Message);
            }
        }

        public async Task<T> PutAsync(string endpoint, object data)
        {
            try
            {
                var jsonData = JsonConvert.SerializeObject(data);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(endpoint, content);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                throw new Exception("PUT request failed: " + ex.Message);
            }
        }

        public async Task<T> DeleteAsync(string endpoint)
        {
            try
            {
                var response = await client.DeleteAsync(endpoint);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                throw new Exception("DELETE request failed: " + ex.Message);
            }
        }
    }
}
