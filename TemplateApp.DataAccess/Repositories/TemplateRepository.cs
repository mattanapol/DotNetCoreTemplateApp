using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TemplateApp.Services.Interfaces;
using TemplateApp.Services.Interfaces.Repositories;
using TemplateApp.DataAccess.Models;
using TemplateApp.Domain.Models;
using System.Collections.Generic;

namespace TemplateApp.DataAccess.Repositories
{
    public class TemplateRepository: BaseTemplateRepository, ITemplateRepository
    {
        public TemplateRepository(TemplateDbContext dbContext, ITypeMappingService typeMappingService): base(dbContext, typeMappingService)
        {
        }

        public async Task<List<TemplateModel>> GetAllTemplateData()
        {
            var templateModel = await DbContext.TemplateModels.ToListAsync();

            return TypeMappingService.Map<List<TemplateModelDb>, List<TemplateModel>>(templateModel);
        }

        public async Task<string> GetTemplateData(int id)
        {
            var templateModel = await DbContext.TemplateModels.SingleOrDefaultAsync(e => e.Id == id);

            return templateModel.Content;
        }

        public async Task<TemplateModel> PutTemplateData(string data)
        {
            var templateModelDb = new TemplateModelDb() { Content = data };
            DbContext.TemplateModels.Add(templateModelDb);
            await DbContext.SaveChangesAsync();

            return TypeMappingService.Map<TemplateModelDb, TemplateModel>(templateModelDb);
        }
    }
}
