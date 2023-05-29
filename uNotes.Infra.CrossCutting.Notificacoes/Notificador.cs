using FluentValidation.Results;

namespace uNotes.Infra.CrossCutting.Notificacoes
{
    public class Notificador : INotificador
    {
        private readonly List<Notificacao> _notificacoes;

        public Notificador()
        {
            _notificacoes = new List<Notificacao>();
        }

        public void AdicionarNotificacao(string notificacao)
        {
            _notificacoes.Add(new Notificacao(notificacao));
        }

        public void AdicionarNotificacao(Notificacao notificacao)
        {
            _notificacoes.Add(notificacao);
        }

        public List<Notificacao> ObterNotificacoes()
        {
            return _notificacoes;
        }

        public bool TemNotificacao()
        {
            return _notificacoes.Any();
        }

        public void AdicionarNotificacoes(List<ValidationFailure> erros)
        {
            foreach (var erro in erros)
            {
                AdicionarNotificacao(erro.ErrorMessage);
            }
        }
    }
}
