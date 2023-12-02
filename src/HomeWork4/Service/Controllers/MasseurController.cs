using Commands.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Requests.Request;

namespace Service.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MasseurController : ControllerBase
    {
        private readonly IMasseurCommand _masseurCommand;

        public MasseurController(IMasseurCommand command)
        {
            _masseurCommand = command;
        }

        [HttpPost]
        public IActionResult Create(
        [FromBody] MasseurRequest request)
        {
            return _masseurCommand.CreateMasseur(request);
        }

        [HttpGet]
        public IActionResult Get(
        [FromQuery] Guid id)
        {
            return _masseurCommand.GetMasseur(id);
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return _masseurCommand.GetMasseurs();
        }

        [HttpDelete]
        public IActionResult Delete(
        [FromQuery] Guid id)
        {
            return _masseurCommand.DeleteMasseur(id);
        }

        [HttpPut]
        public IActionResult Update(
        [FromQuery] Guid id,
        [FromBody] MasseurRequest request)
        {
            return _masseurCommand.UpdateMasseur(request, id);
        }
    }
}
