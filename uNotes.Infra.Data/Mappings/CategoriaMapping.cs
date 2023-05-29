using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using uNotes.Domain.Entidades;
using uNotes.Infra.Data.Constantes;

namespace uNotes.Infra.Data.Mappings
{
    internal class CategoriaMapping : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable(Tabelas.Categoria);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Titulo).IsRequired();
            builder.Property(x => x.CategoriaPai).IsRequired(false);

            builder.HasMany(x => x.Documentos)
                .WithOne(x => x.Categoria)
                .HasForeignKey(x => x.CategoriaId);

            builder.HasMany(x => x.Usuarios)
                .WithOne(x => x.Categoria)
                .HasForeignKey(x => x.CategoriaId);
        }
    }
}
