using System;
using System.Threading.Tasks;
namespace TemplateApp.Services.Interfaces
{
    public interface ITemplateService
    {
        Task<string> TemplateServiceMethod(int arg);

        Task TemplateServiceMethod2(string arg);
    }
}
