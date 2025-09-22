using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceMachine.Core.Models
{
    public class ApiWeb_Up
    {

            public int id { get; set; }
            public string name { get; set; }
            public string port { get; set; }
            public string ip { get; set; }
            public string password { get; set; }
            public object refer_code { get; set; } // null nên dùng object
            public int is_pt { get; set; }
            public int is_control_door { get; set; }
            public int is_door_dev { get; set; }
            public int is_allow_in { get; set; }
            public int is_allow_out { get; set; }
            public int is_admin_dev { get; set; }
            public List<object> room { get; set; } // JSON là mảng rỗng
            public int branch_id { get; set; }
            public List<object> rehearsals { get; set; }
            public List<object> machine_rehearsals { get; set; }
            public List<object> user_timezone { get; set; }
            public object machine_control_door { get; set; }
            public object machine_branch_id { get; set; }
            public int is_auto_cancel_control_door { get; set; }
            public int is_auto_save_log_employee { get; set; }
        }

        public class Meta
        {
            public int status_code { get; set; }
            public string message { get; set; }
        }

        public class Root
        {
            public ApiWeb_Up data { get; set; }
            public Meta meta { get; set; }
        }


    }

