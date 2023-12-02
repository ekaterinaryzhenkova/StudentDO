using Data.Responses;
using MassTransit;
using RabbitClient.Publishers;
using Requests.Request;

namespace Service.Publishers
{
    public class CreateClientMessagePublisher : ICreateClientPublisher
    {
        private readonly IRequestClient<CreateClientRequest> _requestClient;
        private readonly ILogger<CreateClientMessagePublisher> _logger;

        public CreateClientMessagePublisher(
          IRequestClient<CreateClientRequest> requestClient,
          ILogger<CreateClientMessagePublisher> logger)
        {
            _requestClient = requestClient;
            _logger = logger;
        }

        public async Task<CreateClientResponse> CreateClientAsync(CreateClientRequest request)
        {
            _logger.LogInformation("Starting sending request from client");

            Response<CreateClientResponse>? result = await _requestClient.GetResponse<CreateClientResponse>(request);

            _logger.LogInformation("Received request from server in client");
            return result.Message;
        }
    }
}
