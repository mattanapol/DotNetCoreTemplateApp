using System;
using Microsoft.EntityFrameworkCore;
using TemplateApp.DataAccess.Models;

namespace TemplateApp.DataAccess
{
    public class TemplateDbContext: DbContext
    {
        public DbSet<TemplateModelDb> TemplateModels { get; set; }

        public TemplateDbContext(string connectionString): base(CreateSqliteOptions(connectionString))
        {
        }

        private static DbContextOptions CreateSqliteOptions(string connectionString)
        {
            var dbContextOptionBuilder = new DbContextOptionsBuilder();
            dbContextOptionBuilder.UseSqlite(connectionString);
            return dbContextOptionBuilder.Options;
        }
    }
}
