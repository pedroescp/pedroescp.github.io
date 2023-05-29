using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using uNotes.Domain.Entidades;
using uNotes.Infra.Data.Constantes;

namespace uNotes.Infra.Data.Mappings
{
    public class ColaboradoresMapping : IEntityTypeConfiguration<Colaboradores>
    {
        public void Configure(EntityTypeBuilder<Colaboradores> builder)
        {
            builder.ToTable(Tabelas.Colaboradores);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.UsuarioId).IsRequired();
            builder.Property(x => x.NotaId).IsRequired();
            builder.Property(x => x.Status).IsRequired();
        }
    }
}
