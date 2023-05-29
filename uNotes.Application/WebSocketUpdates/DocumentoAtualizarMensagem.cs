namespace uNotes.Application.WebSocketUpdates
{
    public class DocumentoAtualizarMensagem
    {
        public Guid DocumentoId { get; set; }
        public string Texto { get; set; }
        public Guid UsuarioId { get; set; }
    }
}
