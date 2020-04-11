using PUCMinas.SGQ.Core.Business.Interfaces;
using PUCMinas.SGQ.Processos.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PUCMinas.SGQ.Processos.Business.Interfaces
{
    public interface IWorkflowDefinicaoRepository : IRepository<WorkflowDefinicao>
    {
        Task<IEnumerable<WorkflowDefinicao>> ObterWorkflowDefinicaoComObjetos();
        Task<WorkflowDefinicao> ObterWorkflowDefinicaoPorIdComObjetos(Guid id);
    }
}
