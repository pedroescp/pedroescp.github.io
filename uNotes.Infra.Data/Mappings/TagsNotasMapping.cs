using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using uNotes.Domain.Entidades;
using uNotes.Infra.Data.Constantes;

namespace uNotes.Infra.Data.Mappings
{
    public class TagsNotasMapping
    {
        public void Configure(EntityTypeBuilder<TagsNotas> builder)
        {
            builder.ToTable(Tabelas.TagsNotas);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.NotaId).IsRequired();
            builder.Property(x => x.TagId).IsRequired();
        }
    }
}
