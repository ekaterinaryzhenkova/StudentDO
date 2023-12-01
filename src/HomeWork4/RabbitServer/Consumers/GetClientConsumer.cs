using Commands.Interfaces;
using Data.Request;
using Data.Responses;
using MassTransit;
using Requests.Request;

namespace RabbitServer.Consumers
{
    public class GetClientConsumer : IConsumer<GetClientRequest>
    {
        private readonly IGetClientCommand _command;
        private readonly ILogger<GetClientConsumer> _logger;

        public GetClientConsumer(
          IGetClientCommand command,
          ILogger<GetClientConsumer> logger)
        {
            _command = command;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<GetClientRequest> context)
        {
            _logger.LogInformation("Received publish from client");

            GetClientResponse response = await _command.GetClientAsync(context.Message);

            await context.RespondAsync(response);
        }
    }
}
