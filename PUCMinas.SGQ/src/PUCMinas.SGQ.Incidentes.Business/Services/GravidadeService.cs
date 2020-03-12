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
    public class GravidadeService : BaseService, IGravidadeService
    {
        private readonly IGravidadeRepository _gravidadeRepository;

        public GravidadeService(IGravidadeRepository gravidadeRepository, INotificador notificador) : base(notificador)
        {
            _gravidadeRepository = gravidadeRepository;
        }

        public async Task<bool> Adicionar(Gravidade gravidade)
        {
            if (!ExecutarValidacao(new GravidadeValidation(), gravidade)) return false;

            if (_gravidadeRepository.Buscar(a => a.Nome == gravidade.Nome).Result.Any())
            {
                Notificar("Já existe uma Gravidade cadastrada com esse nome.");
                return false;
            }

            await _gravidadeRepository.Adicionar(gravidade);
            return true;
        }

        public async Task<bool> Atualizar(Gravidade gravidade)
        {
            if (!ExecutarValidacao(new GravidadeValidation(), gravidade)) return false;

            if (_gravidadeRepository.Buscar(a => a.Nome == gravidade.Nome && a.Id != gravidade.Id).Result.Any())
            {
                Notificar("Já existe uma Gravidade cadastrada com esse nome.");
                return false;
            }

            await _gravidadeRepository.Atualizar(gravidade);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            if (_gravidadeRepository.ObterGravidadeComRNCs(id).Result.RNCs.Any())
            {
                Notificar("A Gravidade já foi vinculada a uma RNC e não pode ser removida.");
                return false;
            }

            await _gravidadeRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _gravidadeRepository?.Dispose();
        }
    }
}
