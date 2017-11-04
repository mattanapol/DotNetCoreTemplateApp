using System;
using System.Threading.Tasks;
using TemplateApp.Domain.Models;

namespace TemplateApp.Services.Interfaces
{
    public interface IPdfGeneratorService
    {
        Task<byte[]> GetPdfFromHtmlAsync(PdfGeneratorInputContent inputContent);
    }
}
