using uNotes.Domain.Enumerators;

namespace uNotes.Application.Responses.Notes
{
    public class NotesObterResponse
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string? Texto { get; set; }
        public Guid CriadorId { get; set; }
        public StatusNota Status { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public Guid UsuarioAtualizacaoId { get; set; }
        public Guid? DocumentoId { get; set; }


    }
}
