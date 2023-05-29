using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using uNotes.Domain.Entidades;
using uNotes.Infra.Data.Constantes;

namespace uNotes.Infra.Data.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable(Tabelas.Usuario);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Login).IsRequired();
            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.Senha).IsRequired();
            builder.Property(x => x.Avatar).IsRequired(false);
            builder.Property(x => x.CargoId).IsRequired(false);
            builder.Property(x => x.Telefone).IsRequired(false);
            builder.Property(x => x.UsuarioPaiId);

            builder.HasMany(x => x.Categorias)
                .WithOne(x => x.Usuario)
                .HasForeignKey(x => x.UsuarioId);
        }
    }
}
