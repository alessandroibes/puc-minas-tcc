using PUCMinas.SGQ.Incidentes.Business.Models;
using System;
using System.Threading.Tasks;

namespace PUCMinas.SGQ.Incidentes.Business.Interfaces
{
    public interface IGravidadeService : IDisposable
    {
        Task<bool> Adicionar(Gravidade gravidade);
        Task<bool> Atualizar(Gravidade gravidade);
        Task<bool> Remover(Guid id);
    }
}
