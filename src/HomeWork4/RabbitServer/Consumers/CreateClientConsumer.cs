using Commands.Interfaces;
using Data.Responses;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Requests.Request;
using Service.Publishers;

namespace RabbitServer.Consumers
{
    public class CreateClientConsumer : IConsumer<CreateClientRequest>
    {
        private readonly ICreateClientCommand _command;
        private readonly ILogger<CreateClientConsumer> _logger;

        public CreateClientConsumer(
          ICreateClientCommand command,
          ILogger<CreateClientConsumer> logger)
        {
            _command = command;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<CreateClientRequest> context)
        {
            _logger.LogInformation("Received publish from client");

            CreateClientResponse response = await _command.CreateClientAsync(context.Message);

            _logger.LogInformation($"Cient with Id: {response.ClientId} was created");

            await context.RespondAsync(response);
        }
    }
}
