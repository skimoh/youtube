//***CODE BEHIND - BY RODOLFO.FONSECA***//
using GraphiQl;
using GraphQLCore.Demo.Queries;
using GraphQueryLanguage.Demo.Demo;
using GraphQueryLanguage.Demo.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using GraphQL;
using GraphQueryLanguage.Demo.Types;

namespace GraphQueryLanguage.Demo
{
    public class Startup
    {
        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Contexto>(options =>
                options.UseSqlite(_configuration.GetConnectionString("sqllitedb"))
            );

            services.AddTransient<IClienteRepository, ClienteRepository>();


            services.
                AddMvc(option => option.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services.AddSingleton<GraphQL.IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));            
            services.AddScoped<ClienteScheme>();
            services.AddScoped<ClienteQuery>();
            services.AddScoped<ClienteType>();
            services.AddScoped<PostReturnType>();
            //services.AddScoped<ClienteMutation>();                        

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphiQl();
            app.UseMvc();
        }
    }
}
