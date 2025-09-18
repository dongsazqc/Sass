using FaceMachine.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceMachine.Core.Helpers
{
    public static class MachineMapping
    {
        private static readonly Dictionary<int, MachineInfo> _machines = new()
    {
        { 1, new MachineInfo { Ip="192.168.0.12", DeviceID=2565490, Username="admin", Password="112233" } }
    };

        public static MachineInfo GetMachine(int machineId)
        {
            if (_machines.TryGetValue(machineId, out var machine))
                return machine;
            throw new Exception($"MachineId {machineId} không tồn tại!");
        }
    }

}
