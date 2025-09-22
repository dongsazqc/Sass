using Newtonsoft.Json;
namespace FaceGetTenant_CLB.Models
{
    public class MetaModel
    {
        [JsonProperty("status_code")]
        public int StatusCode { get; set; }
        [JsonProperty("message")]
        public object Message { get; set; }
        [JsonProperty("url_service")]
        public string UrlService { get; set; }
        [JsonProperty("url_websocket")]
        public string UrlWebsocket { get; set; }
        [JsonProperty("rabbitmq_host")]
        public string RabbitmqHost { get; set; }
    }
}