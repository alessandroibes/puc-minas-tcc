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
    [Route("api/v{version:apiVersion}/workflow")]
    public class WorkflowController : MainController
    {
        private readonly IWorkflowDefinicaoRepository _wfDefRepository;
        private readonly IWorkflowRepository _wfRepository;
        private readonly IWorkflowService _wfService;
        private readonly IPassoService _passoService;
        private readonly IMapper _mapper;

        public WorkflowController(IWorkflowDefinicaoRepository wfDefRepository,
            IWorkflowRepository wfRepository,
            IWorkflowService wfService,
            IPassoService passoService,
            IMapper mapper,
            INotificador notificador,
            IUser appUser) : base(notificador, appUser)
        {
            _wfDefRepository = wfDefRepository;
            _wfRepository = wfRepository;
            _wfService = wfService;
            _passoService = passoService;
            _mapper = mapper;
        }

        [Authorize(Roles = "operador,gerente")]
        [HttpGet("criar-workflow/{workflowDefinicaoId:guid}")]
        public async Task<ActionResult<WorkflowViewModel>> CriarWorkflow(Guid workflowDefinicaoId)
        {
            var wfd = await _wfDefRepository.ObterWorkflowDefinicaoPorIdComObjetos(workflowDefinicaoId);

            if (wfd == null) return NotFound();

            return _mapper.Map<WorkflowViewModel>(await _wfService.IniciarWorkflow(wfd));
        }

        [Authorize(Roles = "operador")]
        [HttpGet("todolist/{workflowId:guid}")]
        public async Task<IEnumerable<PassoViewModel>> ObterListaAtividades(Guid workflowId)
        {
            Workflow workflow = await _wfRepository.ObterPorIdComObjetos(workflowId);

            if (workflow == null || workflow.Passos == null) { return null; }

            return _mapper.Map<IEnumerable<PassoViewModel>>(workflow.Passos);
        }

        [Authorize(Roles = "operador")]
        [HttpPut("todolist/{passoId:guid}")]
        public async Task<ActionResult<PassoViewModel>> AtualizarAtividade(Guid passoId, PassoViewModel passoViewModel)
        {
            if (passoId != passoViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(passoViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _passoService.AtualizarAtividade(_mapper.Map<Passo>(passoViewModel));

            return CustomResponse(passoViewModel);
        }
    }
}
