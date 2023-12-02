using Commands.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Requests.Request;

namespace Service.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly ISessionCommand _sessionCommand;

        public SessionController(ISessionCommand command)
        {
            _sessionCommand = command;
        }

        [HttpPost]
        public IActionResult Create(
        [FromBody] SessionRequest request)
        {
            return _sessionCommand.CreateSession(request);
        }

        [HttpGet]
        public IActionResult Get(
        [FromQuery] Guid id)
        {
            return _sessionCommand.GetSession(id);
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return _sessionCommand.GetSessions();
        }

        [HttpDelete]
        public IActionResult Delete(
        [FromQuery] Guid id)
        {
            return _sessionCommand.DeleteSession(id);
        }

        [HttpPut]
        public IActionResult Update(
        [FromQuery] Guid id,
        [FromBody] SessionRequest request)
        {
            return _sessionCommand.UpdateSession(request, id);
        }
    }
}
