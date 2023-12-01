using Commands.Interfaces;
using Data.Request;
using Data.Responses;
using MassTransit;

namespace RabbitServer.Consumers
{
    public class DeleteClientConsumer : IConsumer<DeleteClientRequest>
    {
        private readonly IDeleteClientCommand _command;
        private readonly ILogger<DeleteClientConsumer> _logger;

        public DeleteClientConsumer(
          IDeleteClientCommand command,
          ILogger<DeleteClientConsumer> logger)
        {
            _command = command;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<DeleteClientRequest> context)
        {
            _logger.LogInformation("Received publish from client");

            DeleteClientResponse response = await _command.DeleteClientAsync(context.Message);

            await context.RespondAsync(response);
        }
    }
}
