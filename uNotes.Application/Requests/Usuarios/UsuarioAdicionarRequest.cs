using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uNotes.Application.Requests.Usuario
{
    public class UsuarioAdicionarRequest
    {
        public string? Login { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? Telefone { get; set; }
        public Guid? CargoId { get; set; }
    }
}
