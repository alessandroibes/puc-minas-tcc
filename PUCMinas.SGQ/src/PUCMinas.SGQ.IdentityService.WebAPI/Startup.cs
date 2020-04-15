using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PUCMinas.SGQ.Core.WebApi.Configuration;
using PUCMinas.SGQ.Core.WebApi.Extensions;
using PUCMinas.SGQ.IdentityService.WebAPI.Configuration;
using PUCMinas.SGQ.IdentityService.WebAPI.Context;

namespace PUCMinas.SGQ.IdentityService.WebAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostingEnvironment hostEnvironment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

            if (hostEnvironment.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<IdentityServiceDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("IdentityServiceConnection"));
            });

            services.AddIdentityConfiguration(Configuration);
            services.AddAutoMapper(typeof(Startup));
            services.WebApiApiIdentityServiceConfigConfig();
            services.AddSwaggerGen(c => c.OperationFilter<SwaggerDefaultValues>());
            services.AddLoggingConfiguration(Configuration);
            services.ResolveApiIdentityServiceConfigDependencies();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors("AllowAll");
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseMvcIdentityServiceConfiguration();
            app.UseSwaggerConfig(provider);
            app.UseLoggingConfiguration();
        }
    }
}
