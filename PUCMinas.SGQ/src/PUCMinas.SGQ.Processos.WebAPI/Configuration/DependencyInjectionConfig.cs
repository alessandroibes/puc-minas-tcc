using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PUCMinas.SGQ.Core.Business.Interfaces;
using PUCMinas.SGQ.Core.Business.Notificacoes;
using PUCMinas.SGQ.Core.WebApi.Extensions;
using PUCMinas.SGQ.Processos.Business.Interfaces;
using PUCMinas.SGQ.Processos.Business.Services;
using PUCMinas.SGQ.Processos.Data.Context;
using PUCMinas.SGQ.Processos.Data.Repository;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace PUCMinas.SGQ.Processos.WebAPI.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ProcessosDbContext>();
            services.AddScoped<INotificador, Notificador>();

            services.AddScoped<IAtividadeRepository, AtividadeRepository>();

            services.AddScoped<IAtividadeService, AtividadeService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}
