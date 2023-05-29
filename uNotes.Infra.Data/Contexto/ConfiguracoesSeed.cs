using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uNotes.Domain.Entidades;

namespace uNotes.Infra.Data.Contexto
{
    public class ConfiguracoesSeed
    {
        private readonly uNotesContext _dbContext;

        public ConfiguracoesSeed(uNotesContext context)
        {
            _dbContext = context;
        }

        public async Task SeedData()
        {
            if (await _dbContext.Usuarios.AnyAsync())
                return;

            await SeedBaseInicial();
        }

        private async Task SeedBaseInicial()
        {
            await using var tran = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var cargo = SeedCargo();
                SeedAdmin(cargo);
                await _dbContext.SaveChangesAsync();
                await tran.CommitAsync();
            }
            catch
            {
                await tran.RollbackAsync();
                throw;
            }
        }

        private Cargo SeedCargo()
        {
            var cargo = new Cargo("Admin", "Administrador do Sistema");
            _dbContext.Add(cargo);
            return cargo;
        }

        private void SeedAdmin(Cargo cargo)
        {
            var usuario = new Usuario
            {
                Id = Guid.NewGuid(),
                Nome = "Admin",
                Login = "uNotesAdmin",
                Email = "admin@unotes.net",
                CargoId = cargo.Id,
                Senha = "JurnJhyUTWbeY0XUPS6bNA==",
                Telefone = "(99)99999-9999",
                Avatar = null,
                DataAtualizacao = DateTime.Now,
                DataInclusao = DateTime.Now,
                DataExclusao = null
            };

            _dbContext.Add(usuario);
        }
    }
}
