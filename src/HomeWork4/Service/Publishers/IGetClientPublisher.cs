using Data.Request;
using Data.Responses;

namespace RabbitClient.Publishers
{
    public interface IGetClientPublisher
    {
        Task<GetClientResponse> GetClientAsync(GetClientRequest request);
    }
}
