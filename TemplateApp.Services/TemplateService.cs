using System;
using System.Threading.Tasks;
using TemplateApp.Services.Interfaces;
using TemplateApp.Services.Interfaces.Repositories;
using TemplateApp.Domain.Models;
using System.Collections.Generic;

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

        public async Task<TemplateModel> TemplateServiceMethod2(string arg)
        {
            return await _templateRepository.PutTemplateData(arg);
        }

        public async Task<List<TemplateModel>> TemplateServiceMethod3()
        {
            return await _templateRepository.GetAllTemplateData();
        }
    }
}
