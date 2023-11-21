using Commands.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Requests.Request;

namespace Service.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientCommand _clientCommand;

        public ClientController(IClientCommand command)
        {
            _clientCommand = command;
        }

        [HttpPost]
        public IActionResult Create(
        [FromServices] IClientCommand _clientCommand,
        [FromBody] ClientRequest request)
        {
            return _clientCommand.CreateClient(request);
        }

        [HttpGet]
        public IActionResult Get(
        [FromServices] IClientCommand _clientCommand,
        [FromQuery] Guid id)
        {
            return _clientCommand.GetClient(id);
        }

        [HttpGet("all")]
        public IActionResult GetAll(
        [FromServices] IClientCommand _clientCommand)
        {
            return _clientCommand.GetClients();
        }

        [HttpDelete]
        public IActionResult Delete(
        [FromServices] IClientCommand _clientCommand,
        [FromQuery] Guid id)
        {
            return _clientCommand.DeleteClient(id);
        }

        [HttpPut]
        public IActionResult Update(
        [FromServices] IClientCommand _clientCommand,
        [FromQuery] Guid id,
        [FromBody] ClientRequest request)
        {
           return _clientCommand.UpdateClient(request, id);
        }
    }
}
