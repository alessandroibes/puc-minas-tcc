using PUCMinas.SGQ.Processos.Business.Models;
using System;
using System.Threading.Tasks;

namespace PUCMinas.SGQ.Processos.Business.Interfaces
{
    public interface IWorkflowDefinicaoService : IDisposable
    {
        Task<bool> Adicionar(WorkflowDefinicao workflowDefinicao);
        Task<bool> Atualizar(WorkflowDefinicao workflowDefinicaoparada);
        Task<bool> Remover(Guid id);
    }
}
