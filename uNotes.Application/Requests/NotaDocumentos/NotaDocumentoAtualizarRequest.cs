using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uNotes.Application.Requests.NotaDocumentos
{
    public class NotaDocumentoAtualizarRequest
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string? Texto { get; set; }
        public Guid CriadorId { get; set; }
        [JsonIgnore]
        public Guid UsuarioAtualizacaoId { get; set; }
        public Guid? DocumentoId { get; set; }
    }
}
