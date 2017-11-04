using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TemplateApp.Services.Interfaces;
using TemplateApp.Domain.Models;
using System.IO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TemplateApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PdfController : Controller
    {
        private readonly IPdfGeneratorService _pdfGeneratorService;

        public PdfController(IPdfGeneratorService pdfGeneratorService)
        {
            _pdfGeneratorService = pdfGeneratorService ?? throw new ArgumentNullException(nameof(pdfGeneratorService));;
        }

        // POST api/values
        [HttpPost]
        public async Task<FileStreamResult> Post([FromBody]PdfGeneratorInputContent value)
        {
            var result = await _pdfGeneratorService.GetPdfFromHtmlAsync(value);
            Stream stream = new MemoryStream(result);
            var streamResult = new FileStreamResult(stream, "application/pdf")
            {
                FileDownloadName = "report.pdf"
            };
            return streamResult;
        }
    }
}
