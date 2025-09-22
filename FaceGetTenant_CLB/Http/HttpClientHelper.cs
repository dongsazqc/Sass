using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
namespace FaceGetTenant_CLB.Http
{
    public class HttpClientHelper
    {
        private readonly RestClient client;
        public HttpClientHelper()
        {
            //client = new RestClient(Properties.Settings.Default.base_url_api);
            client = new RestClient(CoreDataUtils.tenantUrlApi);
            client.UseNewtonsoftJson();
        }

    }
}
