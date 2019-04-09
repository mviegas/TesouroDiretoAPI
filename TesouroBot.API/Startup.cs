using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;

namespace tesourobot
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(options =>
            {
                var applicationBasePath = AppContext.BaseDirectory;
                var applicationName = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
                var xmlDocumentPath = Path.Combine(applicationBasePath, $"{applicationName}.xml");

                if (File.Exists(xmlDocumentPath))
                {
                    options.IncludeXmlComments(xmlDocumentPath);
                }

                options.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "TesouroBot API",
                        Version = "v1",
                        Description = "API para consulta dos Títulos disponíveis para compra/venda no Tesouro Direto",
                        Contact = new Contact
                        {
                            Name = "Mateus Viegas",
                            Email = "mateuscviegas@gmail.com",
                        }
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                string swaggerJsonBasePath = string.IsNullOrWhiteSpace(options.RoutePrefix) ? "." : "..";

                options.RoutePrefix = string.Empty;
                options.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "TesouroBot API");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
