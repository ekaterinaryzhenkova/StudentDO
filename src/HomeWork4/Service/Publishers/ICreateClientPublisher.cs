using Data.Responses;
using Requests.Request;

namespace RabbitClient.Publishers
{
    public interface ICreateClientPublisher
    {
        Task<CreateClientResponse> CreateClientAsync(CreateClientRequest request);
    }
}
