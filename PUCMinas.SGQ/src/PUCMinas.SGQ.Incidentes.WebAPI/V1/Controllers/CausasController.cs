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
    public class CausasController : MainController
    {
        private readonly ICausaRepository _causaRepository;
        private readonly ICausaService _causaService;
        private readonly IMapper _mapper;

        public CausasController(ICausaRepository causaRepository,
            ICausaService causaService,
            IMapper mapper,
            INotificador notificador,
            IUser user) : base(notificador, user)
        {
            _causaRepository = causaRepository;
            _causaService = causaService;
            _mapper = mapper;
        }

        //[ClaimsAuthorize("Causa", "Sel")]
        [Authorize(Roles = "operador")]
        [HttpGet]
        public async Task<IEnumerable<CausaViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<CausaViewModel>>(await _causaRepository.ObterTodos());
        }

        //[ClaimsAuthorize("Causa", "Sel")]
        [Authorize(Roles = "operador")]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CausaViewModel>> ObterPorId(Guid id)
        {
            var causa = _mapper.Map<CausaViewModel>(await _causaRepository.ObterPorId(id));

            if (causa == null) return NotFound();

            return causa;
        }

        //[ClaimsAuthorize("Causa", "Add")]
        [Authorize(Roles = "operador")]
        [HttpPost]
        public async Task<ActionResult<CausaViewModel>> Adicionar(CausaViewModel causaViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _causaService.Adicionar(_mapper.Map<Causa>(causaViewModel));

            return CustomResponse(causaViewModel);
        }

        //[ClaimsAuthorize("Causa", "Upd")]
        [Authorize(Roles = "operador")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<CausaViewModel>> Atualizar(Guid id, CausaViewModel causaViewModel)
        {
            if (id != causaViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(causaViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _causaService.Atualizar(_mapper.Map<Causa>(causaViewModel));

            return CustomResponse(causaViewModel);
        }

        //[ClaimsAuthorize("Causa", "Del")]
        [Authorize(Roles = "operador")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<CausaViewModel>> Remover(Guid id)
        {
            var causaViewModel = _mapper.Map<CausaViewModel>(await _causaRepository.ObterPorId(id));

            if (causaViewModel == null) return NotFound();

            await _causaService.Remover(id);

            return CustomResponse(causaViewModel);
        }
    }
}