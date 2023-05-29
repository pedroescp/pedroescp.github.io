using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using uNotes.Domain.Entidades;
using uNotes.Domain.Enumerators;
using uNotes.Infra.Data.Constantes;

namespace uNotes.Infra.Data.Mappings
{
    internal class NotaDocumentoMapping : IEntityTypeConfiguration<NotaDocumento>
    {
        public void Configure(EntityTypeBuilder<NotaDocumento> builder)
        {
            builder.ToTable(Tabelas.NotaDocumento);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Titulo).IsRequired();
            builder.Property(x => x.CriadorId).IsRequired();
            builder.Property(x => x.UsuarioAtualizacaoId).IsRequired();
            builder.Property(x => x.Status).IsRequired().HasDefaultValue(StatusNota.Ativo);
            builder.Property(x => x.DocumentoId).IsRequired();
            builder.Property(x => x.DataInclusao).IsRequired();
            builder.Property(x => x.DataAtualizacao).IsRequired(false);
            builder.Property(x => x.DataExclusao).IsRequired(false);
        }

    }
}
