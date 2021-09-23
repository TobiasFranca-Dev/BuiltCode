using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace BuiltCode.Data
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            //var logger = host.Services.GetRequiredService<ILogger>();

            using (var scope = host.Services.CreateScope())
            {
                using (var context = scope.ServiceProvider.GetRequiredService<AppDbContext>())
                {
                    try
                    {
                        context.Database.Migrate();
                        //logger.LogInformation("Banco de dados migrado com sucesso!");
                    }
                    catch (Exception ex)
                    {
                        //logger.LogError($"Falha ao atualizar o banco de dados: {ex.Message}");
                        throw;
                    }                   
                }
            }

            return host;
        }
    }
}
