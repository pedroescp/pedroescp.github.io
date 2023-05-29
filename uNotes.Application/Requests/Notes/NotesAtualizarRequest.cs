using Newtonsoft.Json;

namespace uNotes.Application.Requests.Notes
{
    public class NotesAtualizarRequest
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string? Texto { get; set; }
        [JsonIgnore]
        public Guid CriadorId { get; set; }
        [JsonIgnore]
        public Guid UsuarioAtualizacaoId { get; set; }
        public Guid? DocumentoId { get; set; }
    }
}

