using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceMachine.Core.Models
{
    public class FaceRequest
    {
        public string @operator { get; set; }
        public Person_FaceRecognitonTerminal info { get; set; }
        public ListPerson_FaceRecognitonTerminal listPerson { get; set; }
    }
}
