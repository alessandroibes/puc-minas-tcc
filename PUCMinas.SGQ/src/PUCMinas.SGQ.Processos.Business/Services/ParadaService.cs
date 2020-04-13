using PUCMinas.SGQ.Core.Business.Interfaces;
using PUCMinas.SGQ.Core.Business.Services;
using PUCMinas.SGQ.Processos.Business.Interfaces;
using PUCMinas.SGQ.Processos.Business.Models;
using PUCMinas.SGQ.Processos.Business.Models.Validations;
using System.Threading.Tasks;

namespace PUCMinas.SGQ.Processos.Business.Services
{
    public class ParadaService : BaseService, IParadaService
    {
        private readonly IParadaRepository _paradaRepository;
        private readonly IUser _user;

        public ParadaService(IParadaRepository paradaRepository,
            IUser user,
            INotificador notificador) : base(notificador)
        {
            _paradaRepository = paradaRepository;
            _user = user;
        }

        public async Task<bool> Adicionar(Parada parada)
        {
            parada.OperadorId = _user.GetUserId();

            if (!ExecutarValidacao(new ParadaValidation(), parada)) return false;

            if (!_user.IsInRole("operador"))
            {
                Notificar("Somente um operador pode registrar uma Parada.");
                return false;
            }

            await _paradaRepository.Adicionar(parada);
            return true;
        }

        public void Dispose()
        {
            _paradaRepository?.Dispose();
        }
    }
}
