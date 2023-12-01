using Data.Request;
using Data.Responses;

namespace RabbitClient.Publishers
{
    public interface IDeleteClientPublisher
    {
        Task<DeleteClientResponse> DeleteClientAsync(DeleteClientRequest request);
    }
}
