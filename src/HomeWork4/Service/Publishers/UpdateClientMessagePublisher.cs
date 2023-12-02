using Data.Responses;
using MassTransit;
using Requests.Request;
using Service.Publishers;

namespace RabbitClient.Publishers
{
    public class UpdateClientMessagePublisher : IUpdateClientPublisher
    {
        private readonly IRequestClient<UpdateClientRequest> _requestClient;
        private readonly ILogger<UpdateClientMessagePublisher> _logger;

        public UpdateClientMessagePublisher(
          IRequestClient<UpdateClientRequest> requestClient,
          ILogger<UpdateClientMessagePublisher> logger)
        {
            _requestClient = requestClient;
            _logger = logger;
        }

        public async Task<UpdateClientResponse> UpdateClientAsync(UpdateClientRequest request, Guid id)
        {
            _logger.LogInformation("Starting sending request from client");

            Response<UpdateClientResponse>? result = await _requestClient.GetResponse<UpdateClientResponse>(request);

            _logger.LogInformation("Received request from server in client");
            return result.Message;
        }
    }
}
