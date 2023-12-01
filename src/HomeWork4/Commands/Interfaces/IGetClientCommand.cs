using Data.Request;
using Data.Responses;

namespace Commands.Interfaces
{
    public interface IGetClientCommand
    {
        Task<GetClientResponse> GetClientAsync(GetClientRequest request);
    }
}
