using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using uNotes.Domain.Entidades;
using uNotes.Infra.Data.Constantes;

namespace uNotes.Infra.Data.Mappings
{
    public class TokenUsuarioMapping : IEntityTypeConfiguration<TokenUsuario>
    {
        public void Configure(EntityTypeBuilder<TokenUsuario> builder)
        {
            builder.ToTable(Tabelas.TokenUsuario);

            builder.HasKey(e => e.Token).HasName("PRIMARY");

            builder.Property(e => e.Token);

            builder.Property(e => e.IdUsuario);

            builder.Property(e => e.DataExpiracao)
                .IsRequired();

            builder.HasOne(e => e.Usuario)
                .WithOne()
                .HasForeignKey<TokenUsuario>(e => e.IdUsuario);
        }
    }
}
