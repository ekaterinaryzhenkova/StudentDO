using Microsoft.AspNetCore.Mvc;
using Requests.Request;

namespace Commands.Interfaces
{
    public interface ISessionCommand
    {
        IActionResult CreateSession(SessionRequest request);
        IActionResult GetSession(Guid id);
        IActionResult GetSessions();
        IActionResult DeleteSession(Guid id);
        IActionResult UpdateSession(SessionRequest request, Guid id);
    }
}
