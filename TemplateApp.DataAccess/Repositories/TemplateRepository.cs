using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TemplateApp.Services.Interfaces.Repositories;
using TemplateApp.DataAccess.Models;
namespace TemplateApp.DataAccess.Repositories
{
    public class TemplateRepository: BaseTemplateRepository, ITemplateRepository
    {
        public TemplateRepository(TemplateDbContext dbContext): base(dbContext)
        {
        }

        public async Task<string> GetTemplateData(int id)
        {
            var templateModel = await DbContext.TemplateModels.SingleOrDefaultAsync(e => e.Id == id);

            return templateModel.Content;
        }

        public async Task PutTemplateData(string data)
        {
            var templateModel = new TemplateModelDb() { Content = data };
            DbContext.TemplateModels.Add(templateModel);
            await DbContext.SaveChangesAsync();
        }
    }
}
