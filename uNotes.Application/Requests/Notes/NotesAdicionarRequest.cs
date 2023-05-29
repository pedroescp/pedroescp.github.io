using System.Text.Json.Serialization;

namespace uNotes.Application.Requests.Notes
{
    public class NotesAdicionarRequest
    {
        public string Titulo { get; set; }
        public string? Texto { get; set; }
        [JsonIgnore]
        public Guid CriadorId { get; set; }
        [JsonIgnore]
        public Guid UsuarioAtualizacaoId { get; set; }
        public Guid? DocumentoId { get; set; }
    }
}
