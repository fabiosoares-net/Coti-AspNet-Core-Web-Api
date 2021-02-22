using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Coti.Infrastructure.Context.Base
{
    public class CotiContextFactory : IDesignTimeDbContextFactory<CotiContext>
    {
        public CotiContext CreateDbContext(string[] args)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "sqlserver.json");

            var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile(path, false)
                .Build();

            var connectionString = configurationBuilder
                .GetSection("ConnectionStrings")
                .GetSection("DB").Value;

            var optionBuilder = new DbContextOptionsBuilder<CotiContext>()
                .UseSqlServer(connectionString)
                .Options;

            return new CotiContext(optionBuilder);
        }
    }
}
