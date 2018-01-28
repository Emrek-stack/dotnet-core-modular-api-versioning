using System;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Frost.WebApiVersioning
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
            var mvcBuilder = services.AddMvc();
            foreach (var assembly in ModuleLoader())
            {
                // register controllers
                mvcBuilder.AddApplicationPart(assembly);
            }
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

        private static Assembly[]  ModuleLoader()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var moduleAssembly = (from assembly in assemblies
                from type in assembly.GetTypes()
                where type.BaseType == typeof(Controller)
                select assembly).ToArray();

            return moduleAssembly;
        }
    }
}