//***CODE BEHIND - BY RODOLFO.FONSECA***//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OData.Edm;
using OData.Demo.Models;
using OData.Demo.Repository;

namespace OData.Demo
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Contexto>(options =>
                  options.UseSqlite(Configuration.GetConnectionString("sqllitedb"))
              );

            services.AddTransient<IClienteRepository, ClienteRepository>();

            services.AddOData();
            services.AddMvc(p => p.EnableEndpointRouting = false);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(b =>
            {
                b.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });

            });


            app.UseMvc(
                        b =>
                        {
                            b.Count().Filter().OrderBy().Expand().Select().MaxTop(null);
                            b.MapODataServiceRoute("odata", "odata", GetEdmModel());
                        });
        }

        private static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Cliente>("Cliente");
            return builder.GetEdmModel();
        }
    }
}
