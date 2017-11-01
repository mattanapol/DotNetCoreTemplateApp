using System;
namespace TemplateApp.DataAccess.Repositories
{
    public abstract class BaseTemplateRepository
    {
        /// <summary>
        /// The database context with an open connection.
        /// </summary>
        protected TemplateDbContext DbContext { get; }

        protected BaseTemplateRepository(TemplateDbContext dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
    }
}
