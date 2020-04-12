using PUCMinas.SGQ.Core.Business.Interfaces;
using PUCMinas.SGQ.Processos.Business.Models;
using System;
using System.Threading.Tasks;

namespace PUCMinas.SGQ.Processos.Business.Interfaces
{
    public interface IWorkflowRepository : IRepository<Workflow>
    {
        Task<Workflow> ObterPorIdComObjetos(Guid id);
    }
}
