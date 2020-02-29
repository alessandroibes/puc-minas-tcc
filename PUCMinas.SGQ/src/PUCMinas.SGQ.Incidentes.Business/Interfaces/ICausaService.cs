using PUCMinas.SGQ.Incidentes.Business.Models;
using System;
using System.Threading.Tasks;

namespace PUCMinas.SGQ.Incidentes.Business.Interfaces
{
    public interface ICausaService : IDisposable
    {
        Task<bool> Adicionar(Causa causa);
        Task<bool> Atualizar(Causa causa);
        Task<bool> Remover(Guid id);
    }
}
