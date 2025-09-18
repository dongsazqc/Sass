using Newtonsoft.Json.Linq;

public static class FaceValidator
{
    public static bool ValidateAddPerson(JObject json, out string error)
    {
        error = "";

        if (json["Operator"]?.ToString() != "AddPerson")
        {
            error = "Operator không phải AddPerson";
            return false;
        }
        if (json["Ip"] == null) { error = "Thiếu Ip"; return false; }
        if (json["DeviceID"] == null) { error = "Thiếu DeviceID"; return false; }
        if (json["Username"] == null) { error = "Thiếu Username"; return false; }

        return true;
    }
}
