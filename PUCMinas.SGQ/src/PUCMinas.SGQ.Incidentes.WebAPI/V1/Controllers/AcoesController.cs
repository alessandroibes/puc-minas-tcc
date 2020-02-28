using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PUCMinas.SGQ.Core.Business.Interfaces;
using PUCMinas.SGQ.Core.WebApi.Controllers;
using PUCMinas.SGQ.Incidentes.Business.Interfaces;
using PUCMinas.SGQ.Incidentes.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PUCMinas.SGQ.Incidentes.WebAPI.V1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AcoesController : MainController
    {
        private readonly IAcaoRepository _acaoRepository;
        private readonly IMapper _mapper;

        public AcoesController(IAcaoRepository acaoRepository,
            IMapper mapper, 
            INotificador notificador, 
            IUser user) : base(notificador, user)
        {
            _acaoRepository = acaoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<AcaoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<AcaoViewModel>>(await _acaoRepository.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<AcaoViewModel>> ObterPorId(Guid id)
        {
            var rnc = _mapper.Map<AcaoViewModel>(await _acaoRepository.ObterPorId(id));

            if (rnc == null) return NotFound();

            return rnc;
        }
    }
}