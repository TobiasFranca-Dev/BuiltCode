using BuiltCode.Application.AppServices.MedicoAppService;
using BuiltCode.Application.AppServices.PacienteAppService;
using BuiltCode.Application.AppServices.ParceiroAppService;
using BuiltCode.Application.AppServices.UsuarioAppService;
using BuiltCode.Data;
using BuiltCode.Data.Repositories;
using BuiltCode.Domain.Core.Notifications;
using BuiltCode.Domain.Models.MedicoAggregate;
using BuiltCode.Domain.Models.PacienteAggregate;
using BuiltCode.Domain.Models.ParceiroAggregate;
using BuiltCode.Domain.Models.UsuarioAggregate;
using BuiltCode.Domain.Services.MedicoService;
using BuiltCode.Domain.Services.PacienteService;
using BuiltCode.Domain.Services.ParceiroService;
using BuiltCode.Domain.Services.UsuarioService;
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
            services.AddScoped<IParceiroService, ParceiroService>();
            services.AddScoped<IPacienteService, PacienteService>();

            services.AddScoped<IUsuarioAppService, UsuarioAppService>();
            services.AddScoped<IMedicoAppService, MedicoAppService>();
            services.AddScoped<IParceiroAppService, ParceiroAppService>();
            services.AddScoped<IPacienteAppService, PacienteAppService>();            

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IMedicoRepository, MedicoRepository>();
            services.AddScoped<IParceiroRepository, ParceiroRepository>();
            services.AddScoped<IPacienteRepository, PacienteRepositorio>();


            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}
