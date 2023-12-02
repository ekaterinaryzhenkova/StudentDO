using Data.Responses;
using Microsoft.AspNetCore.Mvc;
using Requests.Request;

namespace Commands.Interfaces
{
    public interface ICreateClientCommand
    {
        Task<CreateClientResponse> CreateClientAsync(CreateClientRequest request);
    }
}
