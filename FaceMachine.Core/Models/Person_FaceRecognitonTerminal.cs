using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceMachine.Core.Models
{
    public class Person_FaceRecognitonTerminal
    {
        public int PersonType { get; set; }
        public string DeviceID { get; set; }
        public string Name { get; set; } 
        public int Gender { get; set; }
        public int Nation { get; set; }
        public int CardType { get; set; }
        public string IdCard { get; set; }
        public DateTime Birthday { get; set; }
        public string Telnum { get; set; }
        public string Native { get; set; }
        public string Address { get; set; }
        public string Notes { get; set; }
    }
}
