using Commands.Interfaces;
using DbModels;
using Data.Interfaces;
using Requests.Request;
using Data.Mappers;
using Data.Validators;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Commands
{
    public class ClientCommand : IClientCommand
    {
        private readonly IClientRepository _clientRepository;
        private readonly IClientMapper _clientMapper;
        private readonly IClientRequestValidator _createClientRequestValidator;

        public ClientCommand(
            IClientRepository clientRepository,
            IClientMapper clientMapper,
            IClientRequestValidator createClientRequestValidator)
        {
            _clientRepository = clientRepository;
            _clientMapper = clientMapper;
            _createClientRequestValidator = createClientRequestValidator;
        }

        public IActionResult CreateClient(ClientRequest request)
        {
            ValidationResult validationResult = _createClientRequestValidator.Validate(request);

            if (!validationResult.IsValid)
            {
                return new BadRequestObjectResult(validationResult.Errors);
            }

            DbClient client = _clientMapper.Map(request);
            _clientRepository.CreateClient(client);

            return new OkObjectResult(client.Id);
        }

        public IActionResult DeleteClient(Guid id)
        {
            _clientRepository.DeleteClient(id);

            return new OkObjectResult(true);
        }

        public IActionResult GetClient(Guid id)
        {
            DbClient? dbClient = _clientRepository.GetClient(id);

            if (dbClient is null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(dbClient);
        }

        public IActionResult GetClients()
        {
            List<DbClient> _clients = _clientRepository.GetClients();

            return new OkObjectResult(_clients);
        }

        public IActionResult UpdateClient(ClientRequest request, Guid id)
        {
            DbClient? dbClient = _clientRepository.GetClient(id);

            if (dbClient is null)
            {
                return new NotFoundResult();
            }

            ValidationResult validationResult = _createClientRequestValidator.Validate(request);

            if (!validationResult.IsValid)
            {
                return new BadRequestObjectResult(validationResult.Errors);
            }

            DbClient client = _clientMapper.Map(request, id);
            _clientRepository.EditClient(client);

            return new OkResult();
        }
    }
}