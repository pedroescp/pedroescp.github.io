using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using uNotes.Domain.Entidades;
using uNotes.Domain.Enumerators;
using uNotes.Infra.Data.Constantes;

namespace uNotes.Infra.Data.Mappings
{
    public class NotesMapping : IEntityTypeConfiguration<Notes>
    {
        public void Configure(EntityTypeBuilder<Notes> builder)
        {
            builder.ToTable(Tabelas.Notes);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Titulo).IsRequired();
            builder.Property(x => x.CriadorId).IsRequired();
            builder.Property(x => x.UsuarioAtualizacaoId).IsRequired();
            builder.Property(x => x.Status).IsRequired().HasDefaultValue(StatusNota.Ativo);
        }
    }
}
