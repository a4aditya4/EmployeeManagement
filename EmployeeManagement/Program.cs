using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement
{
    //usually console application has program class and Main() method 
    //ASP .Net core app initially starts as console app and main() enrty point for the application.this main method configures asp.net core and starts it and at that point it becomes an ASP.Net core web application
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        //CreateDefaultBuilder(args) is static method that create WebHost with preconfigured defaults.this method maintains the default order of configuartion sources
        //some of the tasks that CreateDefaultBuilder(args) performs
        //1)setting up the WebServer
        //2)Loading the host and application configuration from various configuration sources and
        //3)configuring logging


        //CreateWebHostBuilder method returns object(that implementsIWebHostBuilder) that makes ASP.NET core app as web app Object(IWebHostBuilder).Build() method builds Webhost of this application and Run() method starts app to listen to incoming http request
        //UseStartup(extension method) is configuring startup class(Startup.cs)
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
