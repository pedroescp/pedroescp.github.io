using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using uNotes.Domain.Entidades;

namespace uNotes.Application.Responses.Categorias
{
    public class CategoriaOrdenadaResponse
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public Guid? CategoriaPai { get; set; }
        public List<Documento>? Documentos { get; set; }
        public CategoriaOrdenadaResponse? CategoriaFilho { get; set; }

        public CategoriaOrdenadaResponse GetParentalTree(Guid childId)
        {
            if (Id == childId)
            {
                return new CategoriaOrdenadaResponse { Id = Id, Titulo = Titulo, Documentos = Documentos, CategoriaFilho = null };
            }

            if (CategoriaFilho != null)
            {
                var parentTree = CategoriaFilho.GetParentalTree(childId);
                if (parentTree != null)
                {
                    return new CategoriaOrdenadaResponse { Id = Id, Titulo = Titulo, Documentos = Documentos, CategoriaFilho =  parentTree };
                }
            }

            return null;
        }
    }
}
