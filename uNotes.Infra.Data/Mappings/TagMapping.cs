using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using uNotes.Domain.Entidades;
using uNotes.Infra.Data.Constantes;

namespace uNotes.Infra.Data.Mappings
{
    public class TagMapping : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable(Tabelas.Tag);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.UsuarioId).IsRequired();
            builder.Property(x => x.Nome).IsRequired();
        }
    }
}
