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
    public class PassoService : BaseService, IPassoService
    {
        private readonly IPassoRepository _passoRepository;
        private readonly IWorkflowRepository _wfRepository;
        private readonly IUser _user;

        public PassoService(IPassoRepository passoRepository,
            IWorkflowRepository wfRepository,
            INotificador notificador,
            IUser user) : base(notificador)
        {
            _passoRepository = passoRepository;
            _wfRepository = wfRepository;
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

            passoAnterior.OperadorId = _user.GetUserId();
            passoAnterior.Iniciado = passo.Iniciado;
            passoAnterior.Finalizado = passo.Finalizado;

            if (passoAnterior.DataInicio == null)
            {
                passoAnterior.DataInicio = DateTime.Now;
            }

            if (passoAnterior.Finalizado)
            {
                passoAnterior.DataFim = DateTime.Now;
            }
            else
            {
                passoAnterior.DataFim = null;
            }

            if (!ExecutarValidacao(new PassoValidation(), passoAnterior)) return false;

            var workflow = await _wfRepository.ObterPorId(passoAnterior.WorflowId);

            if (workflow.DataInicio == null)
            {
                workflow.DataInicio = passoAnterior.DataInicio;
            }

            await _passoRepository.Atualizar(passoAnterior);

            bool naofinalizado = _passoRepository.Buscar(p => p.WorflowId == passoAnterior.WorflowId && p.Finalizado == false).Result.Any();

            if (!naofinalizado)
            {
                workflow.Finalizado = true;
                workflow.DataFim = passoAnterior.DataFim;
            }

            await _wfRepository.Atualizar(workflow);

            return true;
        }

        public void Dispose()
        {
            _passoRepository?.Dispose();
        }
    }
}
