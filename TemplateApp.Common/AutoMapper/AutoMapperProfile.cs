using System;
using AutoMapper;
using TemplateApp.Domain.Models;
using TemplateApp.DataAccess.Models;

namespace TemplateApp.Common.AutoMapper
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TemplateModel, TemplateModelDb>();
            CreateMap<TemplateModelDb, TemplateModel>();
        }
    }
}
