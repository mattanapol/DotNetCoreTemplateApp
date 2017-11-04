using System;
using TemplateApp.Services.Interfaces;
using System.Threading.Tasks;
using DinkToPdf.Contracts;
using DinkToPdf;
using TemplateApp.Domain.Models;

namespace TemplateApp.PdfGenerator
{
    public class PdfGeneratorService: IPdfGeneratorService
    {
        private readonly IConverter _pdfConverter;

        public PdfGeneratorService(IConverter pdfConverter)
        {
            _pdfConverter = pdfConverter ?? throw new ArgumentNullException(nameof(pdfConverter));
        }

        public async Task<byte[]> GetPdfFromHtmlAsync(PdfGeneratorInputContent inputContent)
        {
            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    ColorMode = ColorMode.Color,
                    Orientation = inputContent.Portrait.GetValueOrDefault(true) ? Orientation.Portrait : Orientation.Landscape,
                    DPI = inputContent.DPI.GetValueOrDefault(300)
                },
                Objects = {
                    new ObjectSettings() {
                        PagesCount = true,
                        HtmlContent = inputContent.Html,
                        WebSettings = { DefaultEncoding = "utf-8" },
                        //HeaderSettings = { FontSize = 9, Right = "Page [page] of [toPage]", Line = true, Spacing = 2.812 }
                    }
                }
            };
            DinkToPdf.PaperKind paperKind = MapPaperKind(inputContent.PaperKind);
            doc.GlobalSettings.PaperSize = paperKind;
            if (paperKind == DinkToPdf.PaperKind.Custom)
            {
                doc.GlobalSettings.PaperSize = new PechkinPaperSize(inputContent.Width.GetValueOrDefault().ToString(), inputContent.Height.GetValueOrDefault().ToString());
            }
            return await Task.Run(() => {return _pdfConverter.Convert(doc);});
        }

        private DinkToPdf.PaperKind MapPaperKind(TemplateApp.Domain.Models.PaperKind paperKind)
        {
            switch (paperKind){
                case TemplateApp.Domain.Models.PaperKind.A2:
                    return DinkToPdf.PaperKind.A2;
                case TemplateApp.Domain.Models.PaperKind.A3:
                    return DinkToPdf.PaperKind.A3;
                case TemplateApp.Domain.Models.PaperKind.A4:
                    return DinkToPdf.PaperKind.A4;
                case TemplateApp.Domain.Models.PaperKind.A5:
                    return DinkToPdf.PaperKind.A5;
                case TemplateApp.Domain.Models.PaperKind.A6:
                    return DinkToPdf.PaperKind.A6;
                case TemplateApp.Domain.Models.PaperKind.B4:
                    return DinkToPdf.PaperKind.B4;
                case TemplateApp.Domain.Models.PaperKind.B5:
                    return DinkToPdf.PaperKind.B5;
                case TemplateApp.Domain.Models.PaperKind.Letter:
                    return DinkToPdf.PaperKind.Letter;
                case TemplateApp.Domain.Models.PaperKind.Custom:
                    return DinkToPdf.PaperKind.Custom;
                default:
                    return DinkToPdf.PaperKind.A4;
            }
        }
    }
}
