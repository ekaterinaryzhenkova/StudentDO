using Data.Request;
using Data.Responses;
using Requests.Request;

namespace Commands.Interfaces
{
    public interface IUpdateClientCommand
    {
        Task<UpdateClientResponse> UpdateClientAsync(UpdateClientRequest request);
    }
}
