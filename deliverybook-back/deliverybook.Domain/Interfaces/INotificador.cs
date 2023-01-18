using deliverybook.Domain.Notificacoes;
using System.Collections.Generic;

namespace deliverybook.Domain.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();

        List<Notificacao> ObterNotificacoes();

        void Handle(Notificacao notificacao);
    }
}