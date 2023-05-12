using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Http.Headers;

namespace API2
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            /*
             * Проблемний код 1
             
            services.AddControllers(options =>
            {
                // Add XML input/output formatters
                options.InputFormatters.Add(new XmlSerializerInputFormatter(options));
                options.OutputFormatters.Add(new XmlSerializerOutputFormatter());
                // Remove JSON input/output formatters (optional, if you want to only support XML)
                //options.InputFormatters.RemoveType<JsonInputFormatter>();
                // options.OutputFormatters.RemoveType<JsonOutputFormatter>();
            });
            */
            services.Configure<MvcOptions>(options =>
            {
                // Configure XML serializer options
                options.RespectBrowserAcceptHeader = true;

                /*
                 * Проблемний код 2
                 
                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml"));
                */
            });
            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
