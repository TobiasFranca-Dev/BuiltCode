using BuiltCode.Application.AppServices.UsuarioAppService;
using BuiltCode.Data;
using BuiltCode.Data.Repositories;
using BuiltCode.Domain.Core.Notifications;
using BuiltCode.Domain.Models.MedicoAggregate;
using BuiltCode.Domain.Models.PacienteAggregate;
using BuiltCode.Domain.Models.ParceiroAggregate;
using BuiltCode.Domain.Models.UsuarioAggregate;
using BuiltCode.Domain.Services.Medico;
using BuiltCode.Domain.Services.Usuario;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace BuiltCode.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<AppDbContext>();
            services.AddScoped<INotificador, Notificador>();

            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IMedicoService, MedicoService>();

            services.AddScoped<IUsuarioAppService, UsuarioAppService>();

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IMedicoRepository, MedicoRepository>();
            services.AddScoped<IParceiroRepository, ParceiroRepository>();
            services.AddScoped<IPacienteRepository, PacienteRepositorio>();


            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}
