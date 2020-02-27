using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace PUCMinas.SGQ.Processos.WebAPI.Configuration
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        readonly IApiVersionDescriptionProvider provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) => this.provider = provider;

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
            }
        }

        static Info CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new Info()
            {
                Title = "API - Módulo de Controle de Processos Automotivos",
                Version = description.ApiVersion.ToString(),
                Description = "Esta API faz parte da PoC do Sistema de Gestão da Qualidade criado como Trabalho de Conclusão do Curso de Especialização em Arquitetura de Software Distribuído da PUC Minas.",
                Contact = new Contact() { Name = "Alessandro Oliveira", Email = "alessandro.ibes@gmail.com" },
                TermsOfService = "https://opensource.org/licenses/MIT",
                License = new License() { Name = "MIT", Url = "https://opensource.org/licenses/MIT" }
            };

            if (description.IsDeprecated)
            {
                info.Description += " Esta versão está obsoleta!";
            }

            return info;
        }
    }
}
