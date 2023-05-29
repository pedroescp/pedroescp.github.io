using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using uNotes.Infra.CrossCutting.Notificacoes;

namespace uNotes.Api
{
    public abstract class BaseController : Controller
    {
        protected readonly INotificador _notificador;
        private readonly ILogger _logger;
        private string ActionName => ControllerContext.RouteData.Values["action"].ToString();
        private string ControllerName => ControllerContext.RouteData.Values["controller"].ToString();

        protected Guid UsuarioId { get; set; }
        protected bool UsuarioAutenticado { get; set; }

        protected BaseController(INotificador notificador,
                                 ILogger logger)
        {
            _notificador = notificador;
            _logger = logger;
        }

        #region Notificação

        protected bool OperacaoValida()
            => !_notificador.TemNotificacao();

        protected List<string> ObterNotificacoes()
        {
            var mensagens = _notificador
                .ObterNotificacoes()
                .Select(n => n.Mensagem)
                .ToList();

            return mensagens;
        }

        protected void NotificarErro(string mensagem)
        {
            _notificador.AdicionarNotificacao(new Notificacao(mensagem));
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notificador.ObterNotificacoes().Select(n => n.Mensagem)
            });
        }


        protected ActionResult CustomError(string error)
        {
            NotificarErro(error);

            return CustomResponse();
        }

        protected ActionResult CustomError(Exception ex)
        {
            LogException(ex);

            NotificarErro("Erro interno, favor contatar o suporte!");

            return CustomResponse();
        }

        protected ActionResult CustomError(ValidationResult result)
        {
            if (result.IsValid) return Ok();

            var errors = result.Errors.Select(p => p.ErrorMessage);

            foreach (var error in errors) NotificarErro(error);

            return CustomResponse();
        }

        protected ActionResult CustomError(ModelStateDictionary modelState)
        {
            if (modelState.IsValid) return Ok();

            var propErrors = modelState
                .Keys
                .Where(k => modelState[k].Errors.Any())
                .Select(k => (Key: k, Error: modelState[k].Errors[0]));

            var errors = propErrors.Select(x =>
            {
                var (key, error) = x;

                var errorMessage = error.Exception == null
                    ? error.ErrorMessage
                    : error.Exception.Message;

                return $"[{key}] - {errorMessage}";
            });

            foreach (var error in errors) NotificarErro(error);

            return CustomResponse();
        }

        protected IActionResult CustomPostResponse(object result = null)
        {
            if (OperacaoValida())
            {
                return Created("", new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notificador.ObterNotificacoes().Select(n => n.Mensagem)
            });
        }

        protected IActionResult CustomPutResponse(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notificador.ObterNotificacoes().Select(n => n.Mensagem)
            });
        }

        protected IActionResult CustomDeleteResponse(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notificador.ObterNotificacoes().Select(n => n.Mensagem)
            });
        }

        #endregion

        #region Log

        protected void LogException(Exception ex)
        {
            _logger.LogError(ex, "{controllerName} - {actionName}", ControllerName, ActionName);
        }

        #endregion
    }
}
