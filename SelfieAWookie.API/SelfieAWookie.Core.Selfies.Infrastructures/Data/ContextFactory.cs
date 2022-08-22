using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace SelfieAWookie.Core.Selfies.Infrastructures.Data
{
    public class ContexteFactory : IDesignTimeDbContextFactory<Contexte>
    {
        public Contexte CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json");
            var config = builder.Build();

            string ConnexionString = config.GetConnectionString("defaultConnexion");

            var optionsBuilder = new DbContextOptionsBuilder<Contexte>();
            optionsBuilder.UseSqlServer(ConnexionString);

            return new Contexte(optionsBuilder.Options);
        }
    }
}
