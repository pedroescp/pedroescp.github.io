using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using uNotes.Domain.Entidades;
using uNotes.Infra.Data.Constantes;

namespace uNotes.Infra.Data.Mappings
{
    internal class DocumentosMapping : IEntityTypeConfiguration<Documento>
    {
        public void Configure(EntityTypeBuilder<Documento> builder)
        {
            builder.ToTable(Tabelas.Documento);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Titulo).IsRequired();
            builder.Property(x => x.CriadorId).IsRequired();
            builder.Property(x => x.Texto).IsRequired(false);
            builder.Property(x => x.UsuarioAtualizacaoId).IsRequired(false);
            builder.Property(x => x.CategoriaId).IsRequired(false);

            builder.HasMany(x => x.Notas)
                .WithOne(x => x.Documento)
                .HasForeignKey(x => x.DocumentoId);
        }
    }
}
