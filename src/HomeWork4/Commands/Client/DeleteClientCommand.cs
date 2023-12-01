using Commands.Interfaces;
using Data.Repositories.Interfaces;
using Data.Request;
using Data.Responses;
using DbModels;

namespace Commands.Client
{
    public class DeleteClientCommand : IDeleteClientCommand
    {
        private readonly IClientRepository _clientRepository;

        public DeleteClientCommand(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<DeleteClientResponse> DeleteClientAsync(DeleteClientRequest request)
        {
            DbClient dbClient = await _clientRepository.GetClientAsync(request.Id);

            if (dbClient is null)
            {
                return new()
                {
                    IsDeleted = false,
                    Errors = new List<string>() { "Id was not found" }
                };
            }

            await _clientRepository.DeleteClientAsync(request.Id);

            return new()
            {
                IsDeleted = true
            };
        }
    }
}
