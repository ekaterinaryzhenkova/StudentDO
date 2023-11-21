using Microsoft.AspNetCore.Mvc;
using Requests.Request;

namespace Commands.Interfaces
{
    public interface IMasseurCommand
    {
        IActionResult CreateMasseur(MasseurRequest request);
        IActionResult GetMasseur(Guid id);
        IActionResult GetMasseurs();
        IActionResult DeleteMasseur(Guid id);
        IActionResult UpdateMasseur(MasseurRequest request, Guid id);
    }
}
