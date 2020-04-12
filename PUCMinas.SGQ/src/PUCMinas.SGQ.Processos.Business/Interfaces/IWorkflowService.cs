using PUCMinas.SGQ.Processos.Business.Models;
using System;
using System.Threading.Tasks;

namespace PUCMinas.SGQ.Processos.Business.Interfaces
{
    public interface IWorkflowService : IDisposable
    {
        Task<Workflow> IniciarWorkflow(WorkflowDefinicao wfDef);
        Task<bool> Adicionar(Workflow workflow);
        Task<bool> Atualizar(Workflow workflow);
        Task<bool> Remover(Guid id);
    }
}
