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
using TemplateApp.Common.AutoMapper;
using TemplateApp.PdfGenerator;
using Swashbuckle.AspNetCore.Swagger;
using DinkToPdf.Contracts;
using DinkToPdf;

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
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            });

            // Common
            services.AddSingleton<ITypeMappingService,AutoMapperService>();

            // Data Layer
            services.AddScoped<TemplateDbContext>((arg) => { return new TemplateDbContext(Configuration.GetConnectionString("DefaultConnection")); });
            services.AddScoped<ITemplateRepository,TemplateRepository>();

            // Service Layer
            services.AddScoped<ITemplateService,TemplateService>();

            // Pdf Generator
            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
            services.AddScoped<IPdfGeneratorService, PdfGeneratorService>();

            // Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // Enable middleware to serve generated Swagger as a JSON endpoint.
                app.UseSwagger();

                // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                });
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
