using PUCMinas.SGQ.Core.Business.Interfaces;
using PUCMinas.SGQ.Core.Business.Services;
using PUCMinas.SGQ.Processos.Business.Interfaces;
using PUCMinas.SGQ.Processos.Business.Models;
using PUCMinas.SGQ.Processos.Business.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PUCMinas.SGQ.Processos.Business.Services
{
    public class AtividadeService : BaseService, IAtividadeService
    {
        private readonly IAtividadeRepository _atividadeRepository;

        public AtividadeService(IAtividadeRepository atividadeRepository, INotificador notificador) : base(notificador)
        {
            _atividadeRepository = atividadeRepository;
        }

        public async Task<bool> Adicionar(Atividade atividade)
        {
            if (!ExecutarValidacao(new AtividadeValidation(), atividade)) return false;

            if (_atividadeRepository.Buscar(a => a.Nome == atividade.Nome).Result.Any())
            {
                Notificar("Já existe uma Atividade cadastrada com esse nome.");
                return false;
            }

            await _atividadeRepository.Adicionar(atividade);
            return true;
        }

        public async Task<bool> Atualizar(Atividade atividade)
        {
            if (!ExecutarValidacao(new AtividadeValidation(), atividade)) return false;

            if (_atividadeRepository.Buscar(a => a.Nome == atividade.Nome && a.Id != atividade.Id).Result.Any())
            {
                Notificar("Já existe uma Atividade cadastrada com esse nome.");
                return false;
            }

            await _atividadeRepository.Atualizar(atividade);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            if (_atividadeRepository.ObterAtividadeComPassoDefinicao(id).Result.PassoDefinicoes.Any())
            {
                Notificar("A Atividade já foi vinculada a uma Definição de Passo e não pode ser removida.");
                return false;
            }

            await _atividadeRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _atividadeRepository?.Dispose();
        }
    }
}
