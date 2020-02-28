using PUCMinas.SGQ.Incidentes.Business.Models;
using System;
using System.Threading.Tasks;

namespace PUCMinas.SGQ.Incidentes.Business.Interfaces
{
    public interface IRNCService : IDisposable
    {
        Task<bool> Adicionar(RNC rnc);
        Task<bool> Atualizar(RNC rnc);
        Task<bool> Remover(Guid id);
    }
}
