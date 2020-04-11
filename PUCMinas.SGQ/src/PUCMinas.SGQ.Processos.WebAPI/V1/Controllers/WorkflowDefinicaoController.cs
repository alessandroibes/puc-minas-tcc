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
    public class WorkflowDefinicaoController : MainController
    {
        private readonly IWorkflowDefinicaoRepository _wfDefRepository;
        private readonly IWorkflowDefinicaoService _wfDefService;
        private readonly IMapper _mapper;

        public WorkflowDefinicaoController(IWorkflowDefinicaoRepository wfDefRepository,
            IWorkflowDefinicaoService wfDefService,
            IMapper mapper, 
            INotificador notificador, 
            IUser appUser) : base(notificador, appUser)
        {
            _wfDefRepository = wfDefRepository;
            _wfDefService = wfDefService;
            _mapper = mapper;
        }

        //[Authorize(Roles = "operador,gerente,engenheiro")]
        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<WorkflowDefinicaoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<WorkflowDefinicaoViewModel>>(await _wfDefRepository.ObterWorkflowDefinicaoComObjetos());
        }

        //[Authorize(Roles = "operador,gerente,engenheiro")]
        [AllowAnonymous]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<WorkflowDefinicaoViewModel>> ObterPorId(Guid id)
        {
            var rnc = _mapper.Map<WorkflowDefinicaoViewModel>(await _wfDefRepository.ObterWorkflowDefinicaoPorIdComObjetos(id));

            if (rnc == null) return NotFound();

            return rnc;
        }

        [Authorize(Roles = "engenheiro")]
        [HttpPost]
        public async Task<ActionResult<WorkflowDefinicaoViewModel>> Adicionar(WorkflowDefinicaoViewModel wfDefViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _wfDefService.Adicionar(_mapper.Map<WorkflowDefinicao>(wfDefViewModel));

            return CustomResponse(wfDefViewModel);
        }

        [Authorize(Roles = "engenheiro")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<WorkflowDefinicaoViewModel>> Atualizar(Guid id, WorkflowDefinicaoViewModel wfDefViewModel)
        {
            if (id != wfDefViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(wfDefViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _wfDefService.Atualizar(_mapper.Map<WorkflowDefinicao>(wfDefViewModel));

            return CustomResponse(wfDefViewModel);
        }
    }
}
