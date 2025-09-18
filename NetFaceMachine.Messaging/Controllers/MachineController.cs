using FaceMachine.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace NetFaceMachine.Messaging.Controllers
{
    public class MachineController : Controller
    {
        private readonly FaceMachine.Core.Service.FaceMachineService _service;
        public MachineController()
        {
            _service = new FaceMachine.Core.Service.FaceMachineService();
        }
        public IActionResult Index()
        {
            return View();
        }



        [HttpPost("{machineId}/persons")]
        public async Task<IActionResult> AddPerson(int machineId, [FromBody] Person_FaceRecognitonTerminal person)
        {
            var success = await _service.AddPersonToMachine(machineId, person);
            return Ok(new { success });
        }

    }
}
