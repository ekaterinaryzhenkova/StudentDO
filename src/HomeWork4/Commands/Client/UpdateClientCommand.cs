using Commands.Interfaces;
using Data.Mappers.Interfaces;
using Data.Repositories.Interfaces;
using Data.Responses;
using Data.Validators;
using Data.Validators.Interfaces;
using DbModels;
using FluentValidation.Results;
using Requests.Request;

namespace Commands.Client
{
    public class UpdateClientCommand : IUpdateClientCommand
    {
        private readonly IClientRepository _clientRepository;
        private readonly IClientMapper _clientMapper;
        private readonly IUpdateClientRequestValidator _updateClientRequestValidator;

        public UpdateClientCommand(
            IClientRepository clientRepository,
            IClientMapper clientMapper,
            IUpdateClientRequestValidator updateClientRequestValidator)
        {
            _clientRepository = clientRepository;
            _clientMapper = clientMapper;
            _updateClientRequestValidator = updateClientRequestValidator;
        }

        public async Task<UpdateClientResponse> UpdateClientAsync(UpdateClientRequest request)
        {
            ValidationResult validationResult = _updateClientRequestValidator.Validate(request);
            UpdateClientResponse response = new();

            if (!validationResult.IsValid)
            {
                response.IsUpdated = false;
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

                return response;
            }

            DbClient client = _clientMapper.Map(request);
            await _clientRepository.CreateClientAsync(client);

            response.IsUpdated = true;

            return response;
        }
    }
}
