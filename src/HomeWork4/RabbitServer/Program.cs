using Commands.Client;
using Commands.Interfaces;
using Data.Repositories.Interfaces;
using Data.Repositories;
using MassTransit;
using Data.Validators;
using Data.Mappers.Interfaces;
using Data.Mappers;
using Data.Validators.Interfaces;

namespace RabbitServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddScoped<ICreateClientCommand, CreateClientCommand>();
            builder.Services.AddScoped<IGetClientCommand, GetClientCommand>();
            builder.Services.AddScoped<IDeleteClientCommand, DeleteClientCommand>();
            builder.Services.AddScoped<IUpdateClientCommand, UpdateClientCommand>();
            builder.Services.AddScoped<IClientRepository, ClientRepository>();
            builder.Services.AddTransient<IClientMapper, ClientMapper>();
            builder.Services.AddTransient<ICreateClientRequestValidator, CreateClientValidator>();
            builder.Services.AddTransient<IUpdateClientRequestValidator, UpdateClientValidator>();


            try
            {
                builder.Services.AddMassTransit(x =>
                {
                    x.AddConsumers(typeof(Program).Assembly);
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