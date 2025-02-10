using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Empower.Data.EntityFrameworkCore
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EPowerDbContext>
    {
        public EPowerDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@Directory.GetCurrentDirectory() + "/../Empower.API/appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<EPowerDbContext>();
            var connectionString = configuration.GetConnectionString("HangfireConnection");
            builder.UseSqlServer(connectionString);
            return new EPowerDbContext(builder.Options);
        }
    }
}
