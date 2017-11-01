using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TemplateApp.DataAccess;
using TemplateApp.DataAccess.Repositories;
using TemplateApp.Services;
using TemplateApp.Services.Interfaces;
using TemplateApp.Services.Interfaces.Repositories;

namespace TemplateApp.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddScoped<TemplateDbContext>((arg) => { return new TemplateDbContext(Configuration.GetConnectionString("DefaultConnection")); });
            services.AddScoped<ITemplateRepository,TemplateRepository>();
            services.AddScoped<ITemplateService,TemplateService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
