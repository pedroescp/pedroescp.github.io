using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uNotes.Application.Requests.Usuario
{
    public class UsuarioAutenticarRequest
    {
        public string? EmailLogin { get; set; }
        public string? Senha { get; set; }
    }
}
