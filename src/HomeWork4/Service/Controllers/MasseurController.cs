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
        [FromServices] IMasseurCommand _masseurCommand,
        [FromBody] MasseurRequest request)
        {
            return _masseurCommand.CreateMasseur(request);
        }

        [HttpGet]
        public IActionResult Get(
        [FromServices] IMasseurCommand _masseurCommand,
        [FromQuery] Guid id)
        {
            return _masseurCommand.GetMasseur(id);
        }

        [HttpGet("all")]
        public IActionResult GetAll(
            [FromServices] IMasseurCommand _masseurCommand)
        {
            return _masseurCommand.GetMasseurs();
        }

        [HttpDelete]
        public IActionResult Delete(
        [FromServices] IMasseurCommand _masseurCommand,
        [FromQuery] Guid id)
        {
            return _masseurCommand.DeleteMasseur(id);
        }

        [HttpPut]
        public IActionResult Update(
        [FromServices] IMasseurCommand _masseurCommand,
        [FromQuery] Guid id,
        [FromBody] MasseurRequest request)
        {
            return _masseurCommand.UpdateMasseur(request, id);
        }
    }
}
