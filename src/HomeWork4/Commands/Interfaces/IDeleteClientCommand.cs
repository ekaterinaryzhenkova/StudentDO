using Data.Request;
using Data.Responses;

namespace Commands.Interfaces
{
    public interface IDeleteClientCommand
    {
        Task<DeleteClientResponse> DeleteClientAsync(DeleteClientRequest request);
    }
}
