using System;
using System.Threading.Tasks;
using TemplateApp.Services.Interfaces;
using TemplateApp.Services.Interfaces.Repositories;
namespace TemplateApp.Services
{
    public class TemplateService: ITemplateService
    {
        private readonly ITemplateRepository _templateRepository;
        public TemplateService(ITemplateRepository templateRepository)
        {
            _templateRepository = templateRepository ?? throw new ArgumentNullException(nameof(templateRepository));
        }

        public async Task<string> TemplateServiceMethod(int arg)
        {
            return await _templateRepository.GetTemplateData(arg);
        }

        public async Task TemplateServiceMethod2(string arg)
        {
            await _templateRepository.PutTemplateData(arg);
        }
    }
}
