using Microsoft.AspNetCore.Mvc;
using PUCMinas.SGQ.Core.Business.Interfaces;
using PUCMinas.SGQ.Core.WebApi.Controllers;

namespace PUCMinas.SGQ.Incidentes.WebAPI.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class NaoConformidadesController : MainController
    {
        public NaoConformidadesController(INotificador notificador, IUser user) : base(notificador, user)
        {

        }

        [HttpGet]
        public string Get()
        {
            return "Sou a V1 de Incidentes";
        }
    }
}