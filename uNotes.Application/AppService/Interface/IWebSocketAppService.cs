namespace uNotes.Application.AppService.Interface
{
    public interface IWebSocketAppService
    {
        Task AtualizarDocumento(string json);
    }
}
