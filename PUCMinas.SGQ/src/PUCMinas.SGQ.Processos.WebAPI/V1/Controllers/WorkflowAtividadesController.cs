using Microsoft.AspNetCore.Mvc;
using PUCMinas.SGQ.Core.Business.Interfaces;
using PUCMinas.SGQ.Core.WebApi.Controllers;

namespace PUCMinas.SGQ.Processos.WebAPI.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class WorkflowAtividadesController : MainController
    {
        public WorkflowAtividadesController(INotificador notificador, IUser user) : base(notificador, user)
        {

        }

        [HttpGet]
        public string Get()
        {
            return "Sou a V1 de Processos";
        }
    }
}