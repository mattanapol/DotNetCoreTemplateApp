using System;
using TemplateApp.Services.Interfaces;
namespace TemplateApp.Common.AutoMapper
{
    public class AutoMapperService: ITypeMappingService
    {
        public AutoMapperService()
        {
            if (AutoMapperProvider.Instance == null)
                AutoMapperConfig.RegisterMappings();
        }

        public TDestination Map<TSource, TDestination>(TSource source)
            where TSource : class
            where TDestination : class
        {
            return AutoMapperProvider.Instance.Map<TSource, TDestination>(source);
        }
    }
}
