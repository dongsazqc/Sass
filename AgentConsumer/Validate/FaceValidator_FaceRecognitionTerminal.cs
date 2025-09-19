using Newtonsoft.Json.Linq;

public static class FaceValidator_FaceRecognitionTerminal
{
    /// <summary>
    /// Hàm này dùng để kiểm tra tính hợp lệ của JSON khi dữ liệu được lấy từ Rabbit về có hợp lệ hay ko
    /// </summary>
    /// <param name="json"></param>
    /// <param name="error"></param>
    /// <returns></returns>
    public static bool ValidateAddPerson(JObject json, out string error)
    {
        error = "";

        if (json["operator"]?.ToString() != "AddPerson")

        {   error = "Operator k phải AddPerson ";
            return false;
        }
        if (json["Ip"] == null) { error = "Thiếu Ip"; return false; }
        if (json["DeviceID"] == null) { error = "Thiếu DeviceID"; return false; }
        if (json["Username"] == null) { error = "Thiếu Username"; return false; }

        return true;
    }
    public static bool ValidateSearchPersonList(JObject json, out string error)
    {
        error = "";

        if (json["operator"]?.ToString() != "SearchPersonList")
        {
            error = "Operator k phải SearchPersonList";
            return false;
        }
        if (json["Ip"] == null) { error = "Thiếu Ip"; return false; }
        if (json["DeviceID"] == null) { error = "Thiếu DeviceID"; return false; }
        if (json["Username"] == null) { error = "Thiếu Username"; return false; }

        return true;
    }


}
