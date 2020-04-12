using PUCMinas.SGQ.Core.Business.Interfaces;
using PUCMinas.SGQ.Core.Business.Services;
using PUCMinas.SGQ.Processos.Business.Interfaces;
using PUCMinas.SGQ.Processos.Business.Models;
using PUCMinas.SGQ.Processos.Business.Models.Validations;
using System;
using System.Threading.Tasks;

namespace PUCMinas.SGQ.Processos.Business.Services
{
    public class PassoService : BaseService, IPassoService
    {
        private readonly IPassoRepository _passoRepository;
        private readonly IUser _user;

        public PassoService(IPassoRepository passoRepository,
            INotificador notificador,
            IUser user) : base(notificador)
        {
            _passoRepository = passoRepository;
            _user = user;
        }

        public async Task<bool> AtualizarAtividade(Passo passo)
        {
            var passoAnterior = await _passoRepository.ObterPorId(passo.Id);

            if (passoAnterior == null)
            {
                Notificar("Passo não encontrada.");
                return false;
            }

            passoAnterior.Iniciado = passo.Iniciado;
            passo.Finalizado = passo.Finalizado;

            if (!ExecutarValidacao(new PassoValidation(), passoAnterior)) return false;

            await _passoRepository.Atualizar(passoAnterior);

            return true;
        }

        public void Dispose()
        {
            _passoRepository?.Dispose();
        }
    }
}
