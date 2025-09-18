using Newtonsoft.Json;
using System.Text;

public class HelpersDevice
{
    private readonly HttpClient _client;

    public HelpersDevice()
    {
        _client = new HttpClient();
    }
    private void AddBasicAuthHeader(string username, string password)
    {
        var authToken = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
        _client.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authToken);
    }

    public async Task<string> PostAsync(string url, object payload, string username = null, string password = null)
    {
        if (username != null && password != null)
            AddBasicAuthHeader(username, password);

        var json = JsonConvert.SerializeObject(payload);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync(url, content);

        // Nếu lỗi, trả về nội dung lỗi để debug
        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            return $"ERROR: {response.StatusCode} - {errorContent}";
        }

        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> GetAsync(string url, string username = null, string password = null)
    {
        if (username != null && password != null)
            AddBasicAuthHeader(username, password);


        var response = await _client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }



    public  async Task<string> PutAsync(string endpoint, object payload, string username = null, string password = null)
    {
        if (username != null && password != null)
        {
            AddBasicAuthHeader(username, password);
        }
        var json = JsonConvert.SerializeObject(payload);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _client.PutAsync(endpoint, content);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
    // DELETE tương tự
}
