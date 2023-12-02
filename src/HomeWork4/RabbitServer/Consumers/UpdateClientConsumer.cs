using Commands.Interfaces;
using Data.Responses;
using MassTransit;
using Requests.Request;

namespace RabbitServer.Consumers
{
    public class UpdateClientConsumer : IConsumer<UpdateClientRequest>
    {
        private readonly IUpdateClientCommand _command;
        private readonly ILogger<UpdateClientConsumer> _logger;

        public UpdateClientConsumer(
          IUpdateClientCommand command,
          ILogger<UpdateClientConsumer> logger)
        {
            _command = command;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<UpdateClientRequest> context)
        {
            _logger.LogInformation("Received publish from client");

            UpdateClientResponse response = await _command.UpdateClientAsync(context.Message);

            _logger.LogInformation($"Cient was updated");

            await context.RespondAsync(response);
        }
    }
}
