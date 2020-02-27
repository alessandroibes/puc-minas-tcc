using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PUCMinas.SGQ.Core.Business.Interfaces;
using PUCMinas.SGQ.Core.Business.Notificacoes;
using PUCMinas.SGQ.IdentityService.WebAPI.Context;
using PUCMinas.SGQ.IdentityService.WebAPI.Extensions;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace PUCMinas.SGQ.IdentityService.WebAPI.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            // Context
            services.AddScoped<IdentityServiceDbContext>();

            services.AddScoped<INotificador, Notificador>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}
