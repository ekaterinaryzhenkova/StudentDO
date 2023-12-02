using Data.Mappers.Interfaces;
using Data.Repositories.Interfaces;
using Data.Validators;
using DbModels;
using Microsoft.AspNetCore.Mvc;
using Requests.Request;
using FluentValidation.Results;
using Commands.Interfaces;
using Data.Responses;
using static MassTransit.ValidationResultExtensions;

namespace Commands.Client
{
    public class CreateClientCommand : ICreateClientCommand
    {
        private readonly IClientRepository _clientRepository;
        private readonly IClientMapper _clientMapper;
        private readonly ICreateClientRequestValidator _createClientRequestValidator;

        public CreateClientCommand(
            IClientRepository clientRepository,
            IClientMapper clientMapper,
            ICreateClientRequestValidator createClientRequestValidator)
        {
            _clientRepository = clientRepository;
            _clientMapper = clientMapper;
            _createClientRequestValidator = createClientRequestValidator;
        }

        public async Task<CreateClientResponse> CreateClientAsync(CreateClientRequest request)
        {
            ValidationResult validationResult = _createClientRequestValidator.Validate(request);
            CreateClientResponse response = new CreateClientResponse();

            if (!validationResult.IsValid)
            {
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

                return response;
            }

            DbClient client = _clientMapper.Map(request);
            await _clientRepository.CreateClientAsync(client);

            response.ClientId = client.Id;

            return response;
        }
    }
}
