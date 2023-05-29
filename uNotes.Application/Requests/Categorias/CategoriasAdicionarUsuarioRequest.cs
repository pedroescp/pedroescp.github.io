using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uNotes.Application.Requests.Categorias
{
    public class CategoriasAdicionarUsuarioRequest
    {
        public Guid CategoriaId { get; set; }
        public List<Guid> Usuarios { get; set; }
    }
}
