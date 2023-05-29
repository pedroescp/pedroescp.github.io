using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uNotes.Infra.Data.Contexto
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
