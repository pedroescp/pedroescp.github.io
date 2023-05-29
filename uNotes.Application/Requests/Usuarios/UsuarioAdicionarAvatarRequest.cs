using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uNotes.Application.Requests.Usuario
{
    public class UsuarioAdicionarAvatarRequest
    {
        public IFormFile Arquivo { get; set; }
        public Guid UsuarioId { get; set; }
    }
}
