using PUCMinas.SGQ.Incidentes.Business.Models;
using System;
using System.Threading.Tasks;

namespace PUCMinas.SGQ.Incidentes.Business.Interfaces
{
    public interface INaoConformidadeService : IDisposable
    {
        Task<bool> Adicionar(RNC naoConformidade);
        Task<bool> Atualizar(RNC naoConformidade);
        Task<bool> Remover(Guid id);
    }
}
