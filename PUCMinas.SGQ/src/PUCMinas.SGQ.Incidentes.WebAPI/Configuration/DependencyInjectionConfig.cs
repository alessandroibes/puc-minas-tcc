using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PUCMinas.SGQ.Core.Business.Interfaces;
using PUCMinas.SGQ.Core.Business.Notificacoes;
using PUCMinas.SGQ.Core.WebApi.Extensions;
using PUCMinas.SGQ.Incidentes.Business.Interfaces;
using PUCMinas.SGQ.Incidentes.Business.Services;
using PUCMinas.SGQ.Incidentes.Data.Context;
using PUCMinas.SGQ.Incidentes.Data.Repository;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace PUCMinas.SGQ.Incidentes.WebAPI.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<IncidentesDbContext>();
            services.AddScoped<INotificador, Notificador>();

            services.AddScoped<IRNCRepository, RNCRepository>();
            services.AddScoped<IAcaoRepository, AcaoRepository>();
            services.AddScoped<ICausaRepository, CausaRepository>();
            services.AddScoped<IGravidadeRepository, GravidadeRepository>();

            services.AddScoped<IRNCService, RNCService>();
            services.AddScoped<IAcaoService, AcaoService>();
            services.AddScoped<ICausaService, CausaService>();
            services.AddScoped<IGravidadeService, GravidadeService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}
