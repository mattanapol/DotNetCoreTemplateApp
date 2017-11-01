using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateApp.Domain.Models;
namespace TemplateApp.Services.Interfaces
{
    public interface ITemplateService
    {
        Task<string> TemplateServiceMethod(int arg);

        Task<TemplateModel> TemplateServiceMethod2(string arg);

        Task<List<TemplateModel>> TemplateServiceMethod3();
    }
}
