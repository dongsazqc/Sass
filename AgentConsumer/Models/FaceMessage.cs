using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentConsumer.Models
{
    // Check điều kiện dữ liệu trả về ít nhất phải có những thuộc tính này
    public class FaceMessage
    {
        public string Action { get; set; }
        public string Ip { get; set; }
        public string DeviceID { get; set; }

        public string Username { get; set; }
    }

}
