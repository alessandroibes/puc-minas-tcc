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
    public class RNCsController : MainController
    {
        private readonly IRNCRepository _rncRepository;
        private readonly IMapper _mapper;

        public RNCsController(IRNCRepository rncRepository, IMapper mapper, INotificador notificador, IUser user) : base(notificador, user)
        {
            _rncRepository = rncRepository;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<RNCViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<RNCViewModel>>(await _rncRepository.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<RNCViewModel>> ObterPorId(Guid id)
        {
            var rnc = _mapper.Map<RNCViewModel>(await _rncRepository.ObterPorId(id));

            if (rnc == null) return NotFound();

            return rnc;
        }
    }
}