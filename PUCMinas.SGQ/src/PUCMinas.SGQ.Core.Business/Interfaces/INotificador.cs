using PUCMinas.SGQ.Core.Business.Notificacoes;
using System.Collections.Generic;

namespace PUCMinas.SGQ.Core.Business.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
