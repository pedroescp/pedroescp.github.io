using FluentValidation.Results;

namespace uNotes.Infra.CrossCutting.Notificacoes
{
    public interface INotificador
    {
        void AdicionarNotificacao(Notificacao notificacao);
        void AdicionarNotificacao(string notificacao);
        List<Notificacao> ObterNotificacoes();
        bool TemNotificacao();
        void AdicionarNotificacoes(List<ValidationFailure> erros);
    }
}
