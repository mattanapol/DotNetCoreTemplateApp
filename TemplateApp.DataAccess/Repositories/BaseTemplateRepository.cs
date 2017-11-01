using System;
using TemplateApp.Services.Interfaces;
namespace TemplateApp.DataAccess.Repositories
{
    public abstract class BaseTemplateRepository
    {
        /// <summary>
        /// The database context with an open connection.
        /// </summary>
        protected TemplateDbContext DbContext { get; }

        protected ITypeMappingService TypeMappingService { get; }

        protected BaseTemplateRepository(TemplateDbContext dbContext, ITypeMappingService typeMappingService)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            TypeMappingService = typeMappingService ?? throw new ArgumentNullException(nameof(typeMappingService));
        }
    }
}
