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
    public class AcoesController : MainController
    {
        private readonly IAcaoRepository _acaoRepository;
        private readonly IAcaoService _acaoService;
        private readonly IMapper _mapper;

        public AcoesController(IAcaoRepository acaoRepository,
            IAcaoService acaoService,
            IMapper mapper,
            INotificador notificador,
            IUser user) : base(notificador, user)
        {
            _acaoRepository = acaoRepository;
            _acaoService = acaoService;
            _mapper = mapper;
        }

        //[ClaimsAuthorize("Acao", "Sel")]
        [Authorize(Roles = "operador")]
        [HttpGet]
        public async Task<IEnumerable<AcaoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<AcaoViewModel>>(await _acaoRepository.ObterTodos());
        }

        //[ClaimsAuthorize("Acao", "Sel")]
        [Authorize(Roles = "operador")]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<AcaoViewModel>> ObterPorId(Guid id)
        {
            var rnc = _mapper.Map<AcaoViewModel>(await _acaoRepository.ObterPorId(id));

            if (rnc == null) return NotFound();

            return rnc;
        }

        //[ClaimsAuthorize("Acao", "Add")]
        [Authorize(Roles = "operador")]
        [HttpPost]
        public async Task<ActionResult<AcaoViewModel>> Adicionar(AcaoViewModel acaoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _acaoService.Adicionar(_mapper.Map<Acao>(acaoViewModel));

            return CustomResponse(acaoViewModel);
        }

        //[ClaimsAuthorize("Acao", "Upd")]
        [Authorize(Roles = "operador")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<AcaoViewModel>> Atualizar(Guid id, AcaoViewModel acaoViewModel)
        {
            if (id != acaoViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(acaoViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _acaoService.Atualizar(_mapper.Map<Acao>(acaoViewModel));

            return CustomResponse(acaoViewModel);
        }

        //[ClaimsAuthorize("Acao", "Del")]
        [Authorize(Roles = "operador")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<AcaoViewModel>> Remover(Guid id)
        {
            var acaoViewModel = _mapper.Map<AcaoViewModel>(await _acaoRepository.ObterPorId(id));

            if (acaoViewModel == null) return NotFound();

            await _acaoService.Remover(id);

            return CustomResponse(acaoViewModel);
        }
    }
}