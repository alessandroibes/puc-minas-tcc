using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PUCMinas.SGQ.Core.Business.Interfaces;
using PUCMinas.SGQ.Core.WebApi.Controllers;
using PUCMinas.SGQ.Incidentes.Business.Interfaces;
using PUCMinas.SGQ.Incidentes.Business.Models;
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
        private readonly IRNCService _rncService;
        private readonly IMapper _mapper;

        public RNCsController(IRNCRepository rncRepository, 
            IRNCService rncService,
            IMapper mapper, 
            INotificador notificador, 
            IUser user) : base(notificador, user)
        {
            _rncRepository = rncRepository;
            _rncService = rncService;
            _mapper = mapper;
        }

        //[Authorize(Roles = "gerente,engenheiro")]
        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<RNCViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<RNCViewModel>>(await _rncRepository.ObterTodos());
        }

        //[Authorize(Roles = "gerente,engenheiro")]
        [AllowAnonymous]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<RNCViewModel>> ObterPorId(Guid id)
        {
            var rnc = _mapper.Map<RNCViewModel>(await _rncRepository.ObterPorId(id));

            if (rnc == null) return NotFound();

            return rnc;
        }

        //[Authorize(Roles = "gerente")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<RNCViewModel>> Adicionar(RNCViewModel rncViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _rncService.Adicionar(_mapper.Map<RNC>(rncViewModel));

            return CustomResponse(rncViewModel);
        }

        //[Authorize(Roles = "gerente,engenheiro")]
        [AllowAnonymous]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<RNCViewModel>> Atualizar(Guid id, RNCViewModel rncViewModel)
        {
            if (id != rncViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(rncViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _rncService.Atualizar(_mapper.Map<RNC>(rncViewModel));

            return CustomResponse(rncViewModel);
        }

        [Authorize(Roles = "gerente")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<RNCViewModel>> Remover(Guid id)
        {
            var rncViewModel = _mapper.Map<RNCViewModel>(await _rncRepository.ObterPorId(id));

            if (rncViewModel == null) return NotFound();

            await _rncService.Remover(id);

            return CustomResponse(rncViewModel);
        }
    }
}