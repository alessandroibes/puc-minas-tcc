using PUCMinas.SGQ.Processos.Business.Models;
using System;
using System.Threading.Tasks;

namespace PUCMinas.SGQ.Processos.Business.Interfaces
{
    public interface IParadaService : IDisposable
    {
        Task<bool> Adicionar(Parada parada);
    }
}
