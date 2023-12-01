using Commands.Interfaces;
using Data.Repositories.Interfaces;
using Data.Request;
using Data.Responses;
using DbModels;

namespace Commands.Client
{
    public class GetClientCommand : IGetClientCommand
    {
        private readonly IClientRepository _clientRepository;

        public GetClientCommand(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<GetClientResponse> GetClientAsync(GetClientRequest request)
        {
            DbClient dbClient = await _clientRepository.GetClientAsync(request.Id);

            if (dbClient is null)
            {
                return new()
                {
                    Errors = new List<string>() { "Id was not found"}
                };
            }

            return new()
            {
                Id = dbClient.Id,
                Name = dbClient.Name,
                PhoneNumber = dbClient.PhoneNumber
            };
        }
    }
}
