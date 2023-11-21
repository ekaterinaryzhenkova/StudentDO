using DbModels;
using Microsoft.AspNetCore.Mvc;
using Requests.Request;

namespace Commands.Interfaces
{
    public interface IClientCommand
    {
        IActionResult CreateClient(ClientRequest request);
        IActionResult GetClient(Guid id);
        IActionResult GetClients();
        IActionResult DeleteClient(Guid id);
        IActionResult UpdateClient(ClientRequest request, Guid id);
    }
}
