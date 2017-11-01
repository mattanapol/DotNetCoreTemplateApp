using System;
using System.Threading.Tasks;
namespace TemplateApp.Services.Interfaces.Repositories
{
    public interface ITemplateRepository
    {
        Task<string> GetTemplateData(int id);

        Task PutTemplateData(string data);
    }
}
