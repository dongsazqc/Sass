using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentConsumer.Models
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
