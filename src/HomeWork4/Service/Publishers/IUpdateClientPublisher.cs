using Data.Responses;
using Requests.Request;

namespace RabbitClient.Publishers
{
    public interface IUpdateClientPublisher
    {
        Task<UpdateClientResponse> UpdateClientAsync(UpdateClientRequest request, Guid id);
    }
}
