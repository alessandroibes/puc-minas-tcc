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
    [Route("api/v{version:apiVersion}/gravidade")]
    public class GravidadeController : MainController
    {
        private readonly IGravidadeRepository _gravidadeRepository;
        private readonly IGravidadeService _gravidadeService;
        private readonly IMapper _mapper;

        public GravidadeController(IGravidadeRepository gravidadeRepository,
            IGravidadeService gravidadeService,
            IMapper mapper,
            INotificador notificador,
            IUser user) : base(notificador, user)
        {
            _gravidadeRepository = gravidadeRepository;
            _gravidadeService = gravidadeService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<GravidadeViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<GravidadeViewModel>>(await _gravidadeRepository.ObterTodos());
        }

        [AllowAnonymous]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GravidadeViewModel>> ObterPorId(Guid id)
        {
            var gravidade = _mapper.Map<GravidadeViewModel>(await _gravidadeRepository.ObterPorId(id));

            if (gravidade == null) return NotFound();

            return gravidade;
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<ActionResult<GravidadeViewModel>> Adicionar(GravidadeViewModel gravidadeViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _gravidadeService.Adicionar(_mapper.Map<Gravidade>(gravidadeViewModel));

            return CustomResponse(gravidadeViewModel);
        }

        [Authorize(Roles = "admin")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<GravidadeViewModel>> Atualizar(Guid id, GravidadeViewModel gravidadeViewModel)
        {
            if (id != gravidadeViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(gravidadeViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _gravidadeService.Atualizar(_mapper.Map<Gravidade>(gravidadeViewModel));

            return CustomResponse(gravidadeViewModel);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<GravidadeViewModel>> Remover(Guid id)
        {
            var gravidadeViewModel = _mapper.Map<GravidadeViewModel>(await _gravidadeRepository.ObterPorId(id));

            if (gravidadeViewModel == null) return NotFound();

            await _gravidadeService.Remover(id);

            return CustomResponse(gravidadeViewModel);
        }
    }
}
