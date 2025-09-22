using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceMachine.Core.Models
{
    public class FaceRequest_FaceRecognitionTerminal
    {
        public string @operator { get; set; }
        public object info { get; set; }
        public object picinfo { get; set; }
        public object picURI { get; set; }
    }
}
