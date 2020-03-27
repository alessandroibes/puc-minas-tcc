using PUCMinas.SGQ.Processos.Business.Models;
using System;
using System.Threading.Tasks;

namespace PUCMinas.SGQ.Processos.Business.Interfaces
{
    public interface IAtividadeService : IDisposable
    {
        Task<bool> Adicionar(Atividade atividade);
        Task<bool> Atualizar(Atividade atividade);
        Task<bool> Remover(Guid id);
    }
}
