using BuiltCode.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace BuiltCode.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build()
                                   .MigrateDatabase()
                                   .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
