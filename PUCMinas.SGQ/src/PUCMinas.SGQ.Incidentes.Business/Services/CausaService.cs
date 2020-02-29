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
    public class CausaService : BaseService, ICausaService
    {
        private readonly ICausaRepository _causaRepository;

        public CausaService(ICausaRepository causaRepository, INotificador notificador) : base(notificador)
        {
            _causaRepository = causaRepository;
        }

        public async Task<bool> Adicionar(Causa causa)
        {
            if (!ExecutarValidacao(new CausaValidation(), causa)) return false;

            if (_causaRepository.Buscar(a => a.Nome == causa.Nome).Result.Any())
            {
                Notificar("Já existe uma Causa cadastrada com esse nome.");
                return false;
            }

            await _causaRepository.Adicionar(causa);
            return true;
        }

        public async Task<bool> Atualizar(Causa causa)
        {
            if (!ExecutarValidacao(new CausaValidation(), causa)) return false;

            if (_causaRepository.Buscar(a => a.Nome == causa.Nome && a.Id != causa.Id).Result.Any())
            {
                Notificar("Já existe uma Causa cadastrada com esse nome.");
                return false;
            }

            await _causaRepository.Atualizar(causa);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            if (_causaRepository.ObterCausaComRNCs(id).Result.RNCs.Any())
            {
                Notificar("A Causa já foi vinculada a uma RNC e não pode ser removida.");
                return false;
            }

            await _causaRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _causaRepository?.Dispose();
        }
    }
}
