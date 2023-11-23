using Commands.Interfaces;
using Data.Mappers.Interfaces;
using Data.Repositories.Interfaces;
using Data.Validators;
using DbModels;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Requests.Request;

namespace CLient
{
    public class MasseurCommand : IMasseurCommand
    {
        private readonly IMasseurRepository _masseurRepository;
        private readonly IMasseurMapper _masseurMapper;
        private readonly IMasseurRequestValidator _masseurRequestValidator;

        public MasseurCommand(
            IMasseurRepository masseurRepository,
            IMasseurMapper masseurMapper,
            IMasseurRequestValidator masseurRequestValidator)
        {
            _masseurRepository = masseurRepository;
            _masseurMapper = masseurMapper;
            _masseurRequestValidator = masseurRequestValidator;
        }

        public IActionResult CreateMasseur(MasseurRequest request)
        {
             ValidationResult validationResult = _masseurRequestValidator.Validate(request);

             if (!validationResult.IsValid)
             {
                 return new BadRequestObjectResult(validationResult.Errors);
             }

            DbMasseur masseur = _masseurMapper.Map(request);
            _masseurRepository.CreateMasseur(masseur);

            return new OkObjectResult(masseur.Id);
        }

        public IActionResult DeleteMasseur(Guid id)
        {
            _masseurRepository.DeleteMasseur(id);

            return new OkResult();
        }

        public IActionResult GetMasseur(Guid id)
        {
            DbMasseur? dbMasseur = _masseurRepository.GetMasseur(id);

            if (dbMasseur is null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(dbMasseur);
        }

        public IActionResult GetMasseurs()
        {
            List<DbMasseur>? _masseurs = _masseurRepository.GetMasseurs();

            if (_masseurs is null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(_masseurs);
        }

        public IActionResult UpdateMasseur(MasseurRequest request, Guid id)
        {
            DbMasseur? dbMasseur = _masseurRepository.GetMasseur(id);

            if (dbMasseur is null)
            {
                return new NotFoundResult();
            }

            ValidationResult validationResult = _masseurRequestValidator.Validate(request);

            if (!validationResult.IsValid)
            {
                return new BadRequestObjectResult(validationResult.Errors);
            }

            DbMasseur masseur = _masseurMapper.Map(request, id);
            _masseurRepository.EditMasseur(masseur);

            return new OkResult();
        }
    }
}
