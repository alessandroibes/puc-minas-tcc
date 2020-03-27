using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PUCMinas.SGQ.Core.Business.Interfaces;
using PUCMinas.SGQ.Core.WebApi.Controllers;
using PUCMinas.SGQ.Processos.Business.Interfaces;
using PUCMinas.SGQ.Processos.Business.Models;
using PUCMinas.SGQ.Processos.WebAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PUCMinas.SGQ.Processos.WebAPI.V1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AtividadeController : MainController
    {
        private readonly IAtividadeRepository _atividadeRepository;
        private readonly IAtividadeService _atividadeService;
        private readonly IMapper _mapper;

        public AtividadeController(IAtividadeRepository atividadeRepository,
            IAtividadeService atividadeService,
            IMapper mapper,
            INotificador notificador,
            IUser user) : base(notificador, user)
        {
            _atividadeRepository = atividadeRepository;
            _atividadeService = atividadeService;
            _mapper = mapper;
        }

        //[ClaimsAuthorize("Atividade", "Sel")]
        [Authorize(Roles = "operador")]
        [HttpGet]
        public async Task<IEnumerable<AtividadeViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<AtividadeViewModel>>(await _atividadeRepository.ObterTodos());
        }

        //[ClaimsAuthorize("Atividade", "Sel")]
        [Authorize(Roles = "operador")]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<AtividadeViewModel>> ObterPorId(Guid id)
        {
            var atividade = _mapper.Map<AtividadeViewModel>(await _atividadeRepository.ObterPorId(id));

            if (atividade == null) return NotFound();

            return atividade;
        }

        //[ClaimsAuthorize("Atividade", "Add")]
        [Authorize(Roles = "operador")]
        [HttpPost]
        public async Task<ActionResult<AtividadeViewModel>> Adicionar(AtividadeViewModel atividadeViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _atividadeService.Adicionar(_mapper.Map<Atividade>(atividadeViewModel));

            return CustomResponse(atividadeViewModel);
        }

        //[ClaimsAuthorize("Atividade", "Upd")]
        [Authorize(Roles = "operador")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<AtividadeViewModel>> Atualizar(Guid id, AtividadeViewModel atividadeViewModel)
        {
            if (id != atividadeViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(atividadeViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _atividadeService.Atualizar(_mapper.Map<Atividade>(atividadeViewModel));

            return CustomResponse(atividadeViewModel);
        }

        //[ClaimsAuthorize("Atividade", "Del")]
        [Authorize(Roles = "operador")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<AtividadeViewModel>> Remover(Guid id)
        {
            var acaoViewModel = _mapper.Map<AtividadeViewModel>(await _atividadeRepository.ObterPorId(id));

            if (acaoViewModel == null) return NotFound();

            await _atividadeService.Remover(id);

            return CustomResponse(acaoViewModel);
        }
    }
}
