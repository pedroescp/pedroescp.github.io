namespace uNotes.Application.Requests.Colaboradores
{
    public class ColaboradoresAtualizarRequest
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid NoteId { get; set; }
        public Guid NotaId { get; set; }
        public string? Status { get; set; }

    }
}
