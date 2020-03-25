using PUCMinas.SGQ.Core.Business.Interfaces;
using PUCMinas.SGQ.Core.Business.Services;
using PUCMinas.SGQ.Incidentes.Business.Interfaces;
using PUCMinas.SGQ.Incidentes.Business.Models;
using PUCMinas.SGQ.Incidentes.Business.Models.Validations;
using System;
using System.Threading.Tasks;

namespace PUCMinas.SGQ.Incidentes.Business.Services
{
    public class RNCService : BaseService, IRNCService
    {
        private readonly IRNCRepository _rncRepository;
        private readonly IUser _user;

        public RNCService(IRNCRepository rncRepository, INotificador notificador, IUser user) : base(notificador)
        {
            _rncRepository = rncRepository;
            _user = user;
        }

        public async Task<bool> Adicionar(RNC rnc)
        {
            if (!ExecutarValidacao(new RNCValidation(), rnc)) return false;

            rnc.GerenteCriador = _user.GetUserId();

            await _rncRepository.Adicionar(rnc);
            return true;
        }

        public async Task<bool> Atualizar(RNC rnc)
        {
            if (!ExecutarValidacao(new RNCValidation(), rnc)) return false;

            var rncAnterior = await _rncRepository.ObterPorId(rnc.Id);

            if (rncAnterior == null)
            {
                Notificar("RNC não encontrada.");
                return false;
            }

            // Casos de Uso possíveis "AlterarRNC" e "RevolverRNC"
            if (rncAnterior.Status == StatusRNC.Aberta)
            {
                // Caso de Uso "RevolverRNC"
                if (rnc.Status == StatusRNC.AguardandoConfirmacao || rnc.Status == StatusRNC.AguardandoCorrecao)
                {
                    if (!_user.IsInRole("gerente"))
                    {
                        Notificar("Somente um gerente de qualidade pode resolver uma RNC.");
                        return false;
                    }

                    if (rnc.Status == StatusRNC.Resolvida)
                    {
                        Notificar("Status inconsistente. Não é possível confirmar a resolução de uma RNC aberta.");
                        return false;
                    }
                }

                if (rnc.Status == StatusRNC.AguardandoConfirmacao)
                {
                    rnc.DataResolucao = DateTime.Now;
                }
            }
            // Caso de Uso possível "CorrigirRNC"
            else if (rncAnterior.Status == StatusRNC.AguardandoCorrecao)
            {
                if (!_user.IsInRole("engenheiro"))
                {
                    Notificar("Somente um engenheiro pode corrigir uma RNC.");
                    return false;
                }

                if (rnc.Status != StatusRNC.Aberta)
                {
                    Notificar("Status inconsistente. Essa RNC precisa ser corrigida.");
                    return false;
                }

                rnc.EngenheiroResponsavel = _user.GetUserId();
            }
            // Caso de Uso possível "ConfirmarResolucaoRNC"
            else if (rncAnterior.Status == StatusRNC.AguardandoConfirmacao)
            {
                // Caso de Uso ConfirmarResolucaoRNC
                if (rnc.Status == StatusRNC.Resolvida)
                {
                    if (!_user.IsInRole("gerente"))
                    {
                        Notificar("Somente um gerente de qualidade pode confirmar a resolução de uma RNC.");
                        return false;
                    }
                }
                else
                {
                    Notificar("Status inconsistente. É preciso confirma a resolução desta RNC.");
                    return false;
                }

                rnc.DataFechamento = DateTime.Now;
                rnc.GestorAvaliador = _user.GetUserId();
            }
            else
            {
                Notificar("Não é possível alterar uma RNC resolvida.");
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
