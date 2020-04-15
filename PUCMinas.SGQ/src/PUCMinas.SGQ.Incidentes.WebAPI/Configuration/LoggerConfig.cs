using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PUCMinas.SGQ.Incidentes.WebAPI.Configuration
{
    public static class LoggerConfig
    {
        public static IServiceCollection AddLoggingConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddElmahIo(o =>
            //{
            //    o.ApiKey = "c0acb8e3360f41f481a3cb02312d7502";
            //    o.LogId = new Guid("32fc6931-11e6-424c-b141-80dd8b8ed5a6");
            //});

            //services.AddLogging(builder =>
            //{
            //    builder.AddElmahIo(o =>
            //    {
            //        o.ApiKey = "c0acb8e3360f41f481a3cb02312d7502";
            //        o.LogId = new Guid("32fc6931-11e6-424c-b141-80dd8b8ed5a6");
            //    });
            //    builder.AddFilter<ElmahIoLoggerProvider>(null, LogLevel.Warning);
            //});

            services.AddHealthChecks()
                //.AddElmahIoPublisher("c0acb8e3360f41f481a3cb02312d7502", new Guid("32fc6931-11e6-424c-b141-80dd8b8ed5a6"), "API SGQ.Incidentes")
                //.AddCheck("AspNetUsers", new SqlServerHealthCheck(configuration.GetConnectionString("IncidentesConnection")))
                .AddSqlServer(configuration.GetConnectionString("IncidentesConnection"), name: "BancoSQL");

            services.AddHealthChecksUI();

            return services;
        }

        public static IApplicationBuilder UseLoggingConfiguration(this IApplicationBuilder app)
        {
            //app.UseElmahIo();

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
