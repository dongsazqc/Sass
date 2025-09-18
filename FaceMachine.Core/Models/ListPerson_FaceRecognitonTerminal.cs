using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceMachine.Core.Models
{
    public class ListPerson_FaceRecognitonTerminal
    {
        public int DeviceID { get; set; }    
        public string PersonType { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
