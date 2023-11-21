using CLient;
using Commands;
using Commands.Interfaces;
using Data.Interfaces;
using Data.Mappers;
using Data.Repositories;
using Data.Validators;

namespace Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddTransient<IClientRepository, ClientRepository>();
            builder.Services.AddTransient<IClientCommand, ClientCommand>();
            builder.Services.AddTransient<IClientMapper, ClientMapper>();
            builder.Services.AddTransient<IClientRequestValidator, ClientValidator>();

            builder.Services.AddTransient<IMasseurRepository, MasseurRepository>();
            builder.Services.AddTransient<IMasseurCommand, MasseurCommand>();
            builder.Services.AddTransient<IMasseurMapper, MasseurMapper>();
            builder.Services.AddTransient<IMasseurRequestValidator, MasseurValidator>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}