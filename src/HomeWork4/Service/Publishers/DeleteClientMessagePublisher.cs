using Data.Request;
using Data.Responses;
using MassTransit;

namespace RabbitClient.Publishers
{
    public class DeleteClientMessagePublisher : IDeleteClientPublisher
    {
        private readonly IRequestClient<DeleteClientRequest> _requestClient;
        private readonly ILogger<DeleteClientMessagePublisher> _logger;

        public DeleteClientMessagePublisher(
          IRequestClient<DeleteClientRequest> requestClient,
          ILogger<DeleteClientMessagePublisher> logger)
        {
            _requestClient = requestClient;
            _logger = logger;
        }

        public async Task<DeleteClientResponse> DeleteClientAsync(DeleteClientRequest request)
        {
            _logger.LogInformation("Starting sending request from client");

            Response<DeleteClientResponse>? result = await _requestClient.GetResponse<DeleteClientResponse>(request);

            _logger.LogInformation("Received request from server in client");
            return result.Message;
        }
    }
}
