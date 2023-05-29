using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using uNotes.Domain.Entidades;
using uNotes.Infra.Data.Constantes;

namespace uNotes.Infra.Data.Mappings
{
    public class CargoMapping : IEntityTypeConfiguration<Cargo>
    {
        public void Configure(EntityTypeBuilder<Cargo> builder)
        {
            builder.ToTable(Tabelas.Cargo);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descricao).IsRequired();
            builder.Property(x => x.Nome).IsRequired();
        }
    }
}
