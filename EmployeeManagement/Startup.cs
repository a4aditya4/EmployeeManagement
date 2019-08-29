using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        //Configures services required for the application
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure application's HTTP request processing pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
			//this env.IsDevelopment() extension method will return true only when "ASPNETCORE_ENVIRONMENT" in launchsettings.json set to development.for different environment it can be env.IsProduction() or env.IsStaging()
            if (env.IsDevelopment())
            {
                //UseDeveloperExceptionPage() middleware component send response if there any exception occure in development environment.this middleware should be in the begening of pipeline
                app.UseDeveloperExceptionPage();
            }

			//app.UseFileServer();

			//Run() method is terminal middleware this Run() method takes RequestDelegate(HttpContext) handler,HttpContext object send to this delegate and using this object we can process incoming http request or outgoing response eg. context.Request.Body
			app.Run(async (context) =>
            {
				await context.Response.WriteAsync("Hosting Environment :"+ env.EnvironmentName);
                //logger.LogInformation("MW3 : Request handeled and responses produced");
            });
        }
    }
}
