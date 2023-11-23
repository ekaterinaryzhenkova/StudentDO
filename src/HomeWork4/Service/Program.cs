using CLient;
using Commands;
using Commands.Interfaces;
using Data.Mappers;
using Data.Mappers.Interfaces;
using Data.Repositories;
using Data.Repositories.Interfaces;
using Data.Validators;
using Data.Validators.Interfaces;

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

            builder.Services.AddTransient<ISessionRepository, SessionRepository>();
            builder.Services.AddTransient<ISessionCommand, SessionCommand>();
            builder.Services.AddTransient<ISessionMapper, SessionMapper>();
            builder.Services.AddTransient<ISessionRequestValidator, SessionValidator>();

            builder.Services.AddTransient<IReviewRepository, ReviewRepository>();
            builder.Services.AddTransient<IReviewCommand, ReviewCommand>();
            builder.Services.AddTransient<IReviewMapper, ReviewMapper>();
            builder.Services.AddTransient<IReviewRequestValidator, ReviewValidator>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}