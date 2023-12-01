using CLient;
using Commands.Client;
using Commands.Interfaces;
using Data.Mappers;
using Data.Mappers.Interfaces;
using Data.Repositories;
using Data.Repositories.Interfaces;
using Data.Responses;
using Data.Validators;
using Data.Validators.Interfaces;
using MassTransit;
using RabbitClient.Publishers;
using Requests.Request;
using Service.Publishers;

namespace Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddTransient<ICreateClientPublisher, CreateClientMessagePublisher>();
            builder.Services.AddTransient<IGetClientPublisher, GetClientMessagePublisher>();
            builder.Services.AddTransient<IDeleteClientPublisher, DeleteClientMessagePublisher>();
            builder.Services.AddTransient<IUpdateClientPublisher, UpdateClientMessagePublisher>();

            builder.Services.AddScoped<IClientRepository, ClientRepository>();
            builder.Services.AddTransient<IClientCommand, ClientCommand>();
            builder.Services.AddTransient<IClientMapper, ClientMapper>();
            builder.Services.AddTransient<ICreateClientRequestValidator, CreateClientValidator>();
            builder.Services.AddTransient<IUpdateClientRequestValidator, UpdateClientValidator>();

            builder.Services.AddTransient<IMasseurRepository, MasseurRepository>();
            builder.Services.AddTransient<IMasseurCommand, MasseurCommand>();
            builder.Services.AddTransient<IMasseurMapper, MasseurMapper>();
            builder.Services.AddTransient<IMasseurRequestValidator, MasseurValidator>();

            builder.Services.AddTransient<ISessionRepository, SessionRepository>();
            builder.Services.AddTransient<ISessionCommand, SessionCommand>();
            builder.Services.AddTransient<ISessionMapper, SessionMapper>();
            builder.Services.AddTransient<ISessionRequestValidator, SessionValidator>();

            builder.Services.AddTransient<IReviewRepository, ReviewRepository>();
            builder.Services.AddTransient<IReviewCommand, ReviewCommand>();
            builder.Services.AddTransient<IReviewMapper, ReviewMapper>();
            builder.Services.AddTransient<IReviewRequestValidator, ReviewValidator>();

            builder.Services.AddTransient<ICreateClientCommand, CreateClientCommand>();
            builder.Services.AddTransient<IGetClientCommand, GetClientCommand>();
            builder.Services.AddTransient<IDeleteClientCommand, DeleteClientCommand>();


            try
            {
                builder.Services.AddMassTransit(x =>
                {
                   // x.AddConsumers(typeof(Program).Assembly);
                    x.UsingRabbitMq((context, cfg) =>
                    {
                        cfg.Host("localhost");
                        cfg.ConfigureEndpoints(context);
                    });
                });
            }
            catch (Exception)
            {
                throw new Exception("Failed to connect to rabbitmq");
            }

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}