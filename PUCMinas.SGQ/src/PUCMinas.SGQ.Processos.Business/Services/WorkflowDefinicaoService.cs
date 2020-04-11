using PUCMinas.SGQ.Core.Business.Interfaces;
using PUCMinas.SGQ.Core.Business.Services;
using PUCMinas.SGQ.Processos.Business.Interfaces;
using PUCMinas.SGQ.Processos.Business.Models;
using PUCMinas.SGQ.Processos.Business.Models.Validations;
using System;
using System.Threading.Tasks;

namespace PUCMinas.SGQ.Processos.Business.Services
{
    public class WorkflowDefinicaoService : BaseService, IWorkflowDefinicaoService
    {
        private readonly IWorkflowDefinicaoRepository _wfDefRepository;
        private readonly IPassoDefinicaoRepository _pdDefRepository;
        private readonly IUser _user;

        public WorkflowDefinicaoService(IWorkflowDefinicaoRepository wfDefRepository,
            IPassoDefinicaoRepository pdDefRepository,
            INotificador notificador, 
            IUser user) : base(notificador)
        {
            _wfDefRepository = wfDefRepository;
            _pdDefRepository = pdDefRepository;
            _user = user;
        }

        public async Task<bool> Adicionar(WorkflowDefinicao workflowDefinicao)
        {
            workflowDefinicao.Id = Guid.NewGuid();
            workflowDefinicao.EngenherioCriadorId = _user.GetUserId();

            if (!ExecutarValidacao(new WorkflowDefinicaoValidation(), workflowDefinicao)) return false;

            foreach (var passo in workflowDefinicao.PassosDefinicao)
            {
                passo.WorkflowDefinicaoId = workflowDefinicao.Id;
                if (!ExecutarValidacao(new PassoDefinicaoValidation(), passo)) return false;
            }

            if (!_user.IsInRole("engenheiro"))
            {
                Notificar("Somente um engenheiro pode criar uma Definição de Workflow.");
                return false;
            }

            await _wfDefRepository.Adicionar(workflowDefinicao);
            return true;
        }

        public async Task<bool> Atualizar(WorkflowDefinicao workflowDefinicao)
        {
            var wfDefAnterior = await _wfDefRepository.ObterPorId(workflowDefinicao.Id);

            if (wfDefAnterior == null)
            {
                Notificar("Definição de Workflow não encontrada.");
                return false;
            }

            wfDefAnterior.Nome = workflowDefinicao.Nome;
            wfDefAnterior.PassosDefinicao = workflowDefinicao.PassosDefinicao;

            if (!ExecutarValidacao(new WorkflowDefinicaoValidation(), wfDefAnterior)) return false;

            await _pdDefRepository.RemoverPorWorkflowDefinicao(workflowDefinicao.Id);
            await _wfDefRepository.Atualizar(wfDefAnterior);

            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            //var passosDef = await _passosDefRepository.ObterPorWorkflowDefinicao(id);

            //if (passosDef != null)
            //{
            //    await _passosDefRepository.RemoverPorWorkflowDefinicao(id);
            //}

            await _wfDefRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _wfDefRepository?.Dispose();
            //_passosDefRepository?.Dispose();
        }
    }
}
