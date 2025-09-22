using Newtonsoft.Json;
using System.Collections.Generic;

namespace FaceGetWeb_Api.Models
{
    public class MetaModel
    {
        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("pageLimit")]
        public int PageLimit { get; set; }
    }

    public class TimeAttendanceMachine
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("port")]
        public string Port { get; set; }

        [JsonProperty("ip")]
        public string Ip { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("refer_code")]
        public string ReferCode { get; set; }

        [JsonProperty("is_pt")]
        public int IsPt { get; set; }

        [JsonProperty("is_control_door")]
        public int IsControlDoor { get; set; }

        [JsonProperty("is_door_dev")]
        public int IsDoorDev { get; set; }

        [JsonProperty("is_allow_in")]
        public int IsAllowIn { get; set; }

        [JsonProperty("is_allow_out")]
        public int IsAllowOut { get; set; }

        [JsonProperty("is_admin_dev")]
        public int IsAdminDev { get; set; }

        [JsonProperty("room")]
        public List<object> Room { get; set; }

        [JsonProperty("branch_id")]
        public int BranchId { get; set; }

        [JsonProperty("rehearsals")]
        public List<object> Rehearsals { get; set; }

        [JsonProperty("machine_rehearsals")]
        public List<object> MachineRehearsals { get; set; }

        [JsonProperty("user_timezone")]
        public List<object> UserTimezone { get; set; }

        [JsonProperty("machine_control_door")]
        public object MachineControlDoor { get; set; }

        [JsonProperty("machine_branch_id")]
        public object MachineBranchId { get; set; }

        [JsonProperty("is_auto_cancel_control_door")]
        public int IsAutoCancelControlDoor { get; set; }

        [JsonProperty("is_auto_save_log_employee")]
        public int IsAutoSaveLogEmployee { get; set; }
    }

    public class TimeAttendanceResponse
    {
        [JsonProperty("meta")]
        public MetaModel Meta { get; set; }

        [JsonProperty("data")]
        public List<TimeAttendanceMachine> Data { get; set; }
    }
}
