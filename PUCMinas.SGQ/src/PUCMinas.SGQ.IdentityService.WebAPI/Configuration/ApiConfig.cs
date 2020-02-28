using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace PUCMinas.SGQ.IdentityService.WebAPI.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection WebApiApiIdentityServiceConfigConfig(this IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddApiVersioning(options => {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(options => {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            services.AddCors(options =>
            {
                options.AddPolicy("Development",
                    builder =>
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
                        //.AllowCredentials());

                //options.AddPolicy("Production",
                //    builder =>
                //        builder
                //            .WithMethods("GET")
                //            .WithOrigins("http://desenvolvedor.io")
                //            .SetIsOriginAllowedToAllowWildcardSubdomains()
                //            //.WithHeaders(HeaderNames.ContentType, "x-custom-header")
                //            .AllowAnyHeader());
            });

            return services;
        }

        public static IApplicationBuilder UseMvcIdentityServiceConfiguration(this IApplicationBuilder app)
        {
            app.UseCors("Development");
            app.UseHttpsRedirection();
            app.UseMvc();

            return app;
        }
    }
}
