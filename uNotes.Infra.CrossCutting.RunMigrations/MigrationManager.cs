using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using uNotes.Infra.Data.Contexto;

namespace uNotes.Infra.CrossCutting.RunMigrations
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            try
            {
                using (var scope = host.Services.CreateScope())
                {
                    var appContext = scope.ServiceProvider.GetRequiredService<uNotesContext>();
                    appContext.Database.Migrate();
                }
                return host;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
