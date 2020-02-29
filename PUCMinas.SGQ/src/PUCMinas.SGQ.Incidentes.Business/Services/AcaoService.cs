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
    public class AcaoService : BaseService, IAcaoService
    {
        private readonly IAcaoRepository _acaoRepository;

        public AcaoService(IAcaoRepository acaoRepository, INotificador notificador) : base (notificador)
        {
            _acaoRepository = acaoRepository;
        }

        public async Task<bool> Adicionar(Acao acao)
        {
            if (!ExecutarValidacao(new AcaoValidation(), acao)) return false;

            if (_acaoRepository.Buscar(a => a.Nome == acao.Nome).Result.Any())
            {
                Notificar("Já existe uma Ação cadastrada com esse nome.");
                return false;
            }

            await _acaoRepository.Adicionar(acao);
            return true;
        }

        public async Task<bool> Atualizar(Acao acao)
        {
            if (!ExecutarValidacao(new AcaoValidation(), acao)) return false;

            if (_acaoRepository.Buscar(a => a.Nome == acao.Nome && a.Id != acao.Id).Result.Any())
            {
                Notificar("Já existe uma Ação cadastrada com esse nome.");
                return false;
            }

            await _acaoRepository.Atualizar(acao);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            if (_acaoRepository.ObterAcaoComRNCs(id).Result.RNCs.Any())
            {
                Notificar("A Ação já foi vinculada a uma RNC e não pode ser removida.");
                return false;
            }

            await _acaoRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _acaoRepository?.Dispose();
        }
    }
}
