using PUCMinas.SGQ.Incidentes.Business.Models;
using System;
using System.Threading.Tasks;

namespace PUCMinas.SGQ.Incidentes.Business.Interfaces
{
    public interface IAcaoService : IDisposable
    {
        Task<bool> Adicionar(Acao acao);
        Task<bool> Atualizar(Acao acao);
        Task<bool> Remover(Guid id);
    }
}
