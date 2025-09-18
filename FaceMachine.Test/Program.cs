using FaceMachine.Core.Helpers;
using FaceMachine.Core.Models;
using FaceMachine.Core.Service;

class Program
{
    static async Task Main(string[] args)
    {
        // Tạo instance service
        var service = new FaceMachineService();

        // Tạo Person mẫu đầy đủ
        var person = new Person_FaceRecognitonTerminal
        {
            DeviceID = 2565490,                  
            PersonType = 0,
            Name = "Pham Van Dong",
            Gender = 1,
            Nation = 23,
            CardType = 0,
            IdCard = "100",
            Birthday = new DateTime(1990, 11, 04),
            Telnum = "18888888888",
            Native = "",
            Address = "thanh hoa",                 
            Notes = "dai ca"
        };

        // ID máy trong mapping
        int machineId = 1;

        // Gọi service
        bool success = await service.AddPersonToMachine(machineId, person);


        // In kết quả thân thiện
        Console.WriteLine(success ? "Thêm người thất!" : "Thêm người thành công ");
    }
}
