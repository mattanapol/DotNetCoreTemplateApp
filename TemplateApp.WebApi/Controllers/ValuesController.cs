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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<string> Get(int id)
        {
            return await _templateService.TemplateServiceMethod(id);
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody]string value)
        {
            await _templateService.TemplateServiceMethod2(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
