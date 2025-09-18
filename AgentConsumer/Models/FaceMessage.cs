using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentConsumer.Models
{
    public class FaceMessage
    {
        public string Operator { get; set; }
        public string Ip { get; set; }
        public string DeviceID { get; set; }

        public string Username { get; set; }
    }

}
