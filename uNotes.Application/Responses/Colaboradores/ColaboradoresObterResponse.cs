namespace uNotes.Application.Responses.Colaboradores
{
    public class ColaboradoresObterResponse
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid NoteId { get; set; }
        public Guid NotaId { get; set; }
        public string? Status { get; set; }
    }
}
