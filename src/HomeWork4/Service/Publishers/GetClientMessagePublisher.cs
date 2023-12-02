using Data.Request;
using Data.Responses;
using MassTransit;
using Requests.Request;
using Service.Publishers;

namespace RabbitClient.Publishers
{
    public class GetClientMessagePublisher : IGetClientPublisher
    {
        private readonly IRequestClient<GetClientRequest> _requestClient;
        private readonly ILogger<GetClientMessagePublisher> _logger;

        public GetClientMessagePublisher(
          IRequestClient<GetClientRequest> requestClient,
          ILogger<GetClientMessagePublisher> logger)
        {
            _requestClient = requestClient;
            _logger = logger;
        }

        public async Task<GetClientResponse> GetClientAsync(GetClientRequest request)
        {
            _logger.LogInformation("Starting sending request from client");

            Response<GetClientResponse>? result = await _requestClient.GetResponse<GetClientResponse>(request);

            _logger.LogInformation("Received request from server in client");
            return result.Message;
        }
    }
}
