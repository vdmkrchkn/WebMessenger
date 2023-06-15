using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace app.Context
{
    public class EFDbContextFactory : IDesignTimeDbContextFactory<EFDbContext>
    {
        public EFDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EFDbContext>();

            var config = GetConfiguration();

            var dbProvider = config.GetConnectionString("Provider");
            var connectionString = config.GetConnectionString("DefaultConnection");
            // TODO: migrate to ef5 for enabling args 
            // https://stackoverflow.com/questions/62973966/how-to-pass-createdbcontext-args-parameters
            switch (dbProvider)
            {
                case "MSSQL":
                    optionsBuilder.UseSqlServer(connectionString);
                    break;
                default:
                    optionsBuilder.UseMySql(connectionString);
                    break;
            }

            return new EFDbContext(optionsBuilder.Options);
        }

        private static IConfiguration GetConfiguration()
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") 
                ?? "Development";
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true)
                .Build();
        }
    }
}
