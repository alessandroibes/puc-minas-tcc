using Elmah.Io.AspNetCore;
using Elmah.Io.AspNetCore.HealthChecks;
using Elmah.Io.Extensions.Logging;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace PUCMinas.SGQ.Incidentes.WebAPI.Configuration
{
    public static class LoggerConfig
    {
        public static IServiceCollection AddLoggingConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddElmahIo(o =>
            {
                o.ApiKey = "bf9803cc9bcd45cb960f56d4a1069f13";
                o.LogId = new Guid("fa143189-ec34-48f2-9373-4a9f8868bc65");
            });

            services.AddLogging(builder =>
            {
                builder.AddElmahIo(o =>
                {
                    o.ApiKey = "bf9803cc9bcd45cb960f56d4a1069f13";
                    o.LogId = new Guid("fa143189-ec34-48f2-9373-4a9f8868bc65");
                });
                builder.AddFilter<ElmahIoLoggerProvider>(null, LogLevel.Warning);
            });

            services.AddHealthChecks()
                .AddElmahIoPublisher("bf9803cc9bcd45cb960f56d4a1069f13", new Guid("fa143189-ec34-48f2-9373-4a9f8868bc65"), "API SGQ.Incidentes")
                //.AddCheck("AspNetUsers", new SqlServerHealthCheck(configuration.GetConnectionString("IncidentesConnection")))
                .AddSqlServer(configuration.GetConnectionString("IncidentesConnection"), name: "BancoSQL");

            services.AddHealthChecksUI();

            return services;
        }

        public static IApplicationBuilder UseLoggingConfiguration(this IApplicationBuilder app)
        {
            app.UseElmahIo();

            app.UseHealthChecks("/api/hc", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
            app.UseHealthChecksUI(options => { options.UIPath = "/api/hc-ui"; });

            return app;
        }
    }
}
