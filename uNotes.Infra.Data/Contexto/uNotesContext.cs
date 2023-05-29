using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson.Serialization;
using System.Runtime.Serialization;
using uNotes.Domain.Entidades;
using uNotes.Infra.Data.Mappings;

namespace uNotes.Infra.Data.Contexto
{
    public class uNotesContext : DbContext
    {

        public uNotesContext(DbContextOptions<uNotesContext> options) : base(options)
        {
        }

        public uNotesContext(DbContextOptions<uNotesContext> options, IHttpContextAccessor httpContextAccessor) :
           this(options)
        {
        }

        public DbSet<Usuario>? Usuarios { get; set; }
        public DbSet<Cargo>? Cargos { get; set; }
        public DbSet<Categoria>? Categorias { get; set; }
        public DbSet<UsuarioCategoria> UsuariosCategorias { get; set; }
        public DbSet<Notes>? Notes { get; set; }
        public DbSet<Colaboradores>? Colaboradores { get; set; }
        public DbSet<Documento>? Documentos { get; set; }
        public DbSet<Tag>? Tags { get; set; }
        public DbSet<TagsNotas>? TagsNotas { get; set; }
        public DbSet<NotaDocumento> NotasDocumento { get; set; }
        public uNotesContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMapping());


            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch { throw; }
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await Task.FromResult(SaveChanges());
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
