using System;
namespace TemplateApp.Services.Interfaces
{
    public interface ITypeMappingService
    {
        TDestination Map<TSource, TDestination>(TSource source) where TSource : class where TDestination : class;
    }
}
