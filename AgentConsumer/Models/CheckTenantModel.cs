using AgentConsumer.Models;
using Newtonsoft.Json;

namespace NextFace.Core.Entries
{
    public class CheckTenantModel
    {
        public CheckTenantModel()
        {
            Meta = new MetaModel();
        }
        [JsonProperty("meta")]
        public MetaModel Meta { get; set; }
    }
}
