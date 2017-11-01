using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateApp.Domain.Models;
namespace TemplateApp.Services.Interfaces.Repositories
{
    public interface ITemplateRepository
    {
        Task<string> GetTemplateData(int id);

        Task<TemplateModel> PutTemplateData(string data);

        Task<List<TemplateModel>> GetAllTemplateData();
    }
}
