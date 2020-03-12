using PUCMinas.SGQ.Core.Business.Interfaces;
using PUCMinas.SGQ.Core.Business.Services;
using PUCMinas.SGQ.Incidentes.Business.Interfaces;
using PUCMinas.SGQ.Incidentes.Business.Models;
using PUCMinas.SGQ.Incidentes.Business.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PUCMinas.SGQ.Incidentes.Business.Services
{
    public class RNCService : BaseService, IRNCService
    {
        private readonly IRNCRepository _rncRepository;

        public RNCService(IRNCRepository rncRepository, INotificador notificador) : base(notificador)
        {
            _rncRepository = rncRepository;
        }

        public async Task<bool> Adicionar(RNC rnc)
        {
            if (!ExecutarValidacao(new RNCValidation(), rnc)) return false;

            await _rncRepository.Adicionar(rnc);
            return true;
        }

        public async Task<bool> Atualizar(RNC rnc)
        {
            if (!ExecutarValidacao(new RNCValidation(), rnc)) return false;

            if (_rncRepository.Buscar(a => a.Id == rnc.Id).Result.Any())
            {
                Notificar("RNC não encontrada.");
                return false;
            }

            await _rncRepository.Atualizar(rnc);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            await _rncRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _rncRepository?.Dispose();
        }
    }
}
