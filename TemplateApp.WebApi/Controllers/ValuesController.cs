using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TemplateApp.Services.Interfaces;

namespace TemplateApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ITemplateService _templateService;

        public ValuesController(ITemplateService templateService)
        {
            _templateService = templateService;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _templateService.TemplateServiceMethod3();
            return Ok(result);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            string result = await _templateService.TemplateServiceMethod(id);
            return Ok(result);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]string value)
        {
            var result = await _templateService.TemplateServiceMethod2(value);
            return Ok(result);
        }
    }
}
