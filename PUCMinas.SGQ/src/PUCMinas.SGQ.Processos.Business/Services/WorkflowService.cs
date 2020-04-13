using PUCMinas.SGQ.Core.Business.Interfaces;
using PUCMinas.SGQ.Core.Business.Services;
using PUCMinas.SGQ.Processos.Business.Interfaces;
using PUCMinas.SGQ.Processos.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PUCMinas.SGQ.Processos.Business.Services
{
    public class WorkflowService : BaseService, IWorkflowService
    {
        private readonly IWorkflowDefinicaoRepository _wfDefRepository;
        private readonly IWorkflowRepository _wfRepository;
        private readonly IUser _user;

        public WorkflowService(IWorkflowDefinicaoRepository wfDefRepository,
            IWorkflowRepository wfRepository,
            INotificador notificador,
            IUser user) : base(notificador)
        {
            _wfDefRepository = wfDefRepository;
            _wfRepository = wfRepository;
            _user = user;
        }

        public async Task<Workflow> IniciarWorkflow(WorkflowDefinicao wfDef)
        {
            var wf = new Workflow();
            wf.Id = Guid.NewGuid();
            wf.Nome = wfDef.Nome;
            wf.Iniciado = false;
            wf.Finalizado = false;

            List<Passo> passos = new List<Passo>();
            foreach (var pd in wfDef.PassosDefinicao)
            {
                passos.Add(new Passo() {
                    WorflowId = wf.Id,
                    Titulo = pd.Titulo,
                    Descricao = pd.Descricao,
                    OperadorId = _user.GetUserId(),
                    Iniciado = false,
                    Finalizado = false
                });
            }

            wf.Passos = passos;

            await _wfRepository.Adicionar(wf);
            return wf;
        }

        public void Dispose()
        {
            _wfDefRepository?.Dispose();
            _wfRepository?.Dispose();
        }  
    }
}
