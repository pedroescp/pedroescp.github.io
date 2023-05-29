using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using uNotes.Domain.Entidades;
using uNotes.Infra.Data.Constantes;

namespace uNotes.Infra.Data.Mappings
{
    public class UsuarioCategoriaMapping : IEntityTypeConfiguration<UsuarioCategoria>
    {
        public void Configure(EntityTypeBuilder<UsuarioCategoria> builder)
        {
            builder.ToTable(Tabelas.UsuarioCategoria);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.UsuarioId);
            builder.Property(x => x.CategoriaId);

            builder.HasOne(x => x.Usuario)
                .WithMany(x => x.Categorias)
                .HasForeignKey(x => x.UsuarioId);

            builder.HasOne(x => x.Categoria)
                .WithMany(x => x.Usuarios)
                .HasForeignKey(x => x.CategoriaId);
        }
    }
}
