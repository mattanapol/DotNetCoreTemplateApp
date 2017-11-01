using System;
using System.IO;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using TemplateApp.DataAccess;

namespace TemplateApp.WebApi
{
    public class DesignTimeDbContextFactory: IDesignTimeDbContextFactory<TemplateDbContext>
    {
        public TemplateDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            return new TemplateDbContext(configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
