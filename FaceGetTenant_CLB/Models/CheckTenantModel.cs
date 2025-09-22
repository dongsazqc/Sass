using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceGetTenant_CLB.Models
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
