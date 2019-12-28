using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement
{
    public class Startup
    {
        //private IConfiguration _config;

        //public Startup(IConfiguration config)
        //{
        //    _config = config;
        //}
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Adding MVC services to application dependency injection container
            // AddMvc() method implaments all of MVC 
            services.AddMvc();
            // AddMvcCore() method only add the core MVC services
            //services.AddMvcCore();

            // Loose Coupled MockEmployeeRepository, if MockEmployeeRepository is written correctly
            // then you can change out MockEmployeeRepository below to switch the class in a single 
            // line rather than the tedious of hundreds of class changes
            services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //DefaultFilesOptions defaultFilesOptions = new DefaultFilesOptions();
            //defaultFilesOptions.DefaultFileNames.Clear();
            //defaultFilesOptions.DefaultFileNames.Add("foo.html");


            // Middleware to serve default files
            // default.html, default.htm, index.html, index.htm
            // app.UseDefaultFiles();

            // changed defaultfile to foo.html
            //app.UseDefaultFiles(defaultFilesOptions);

            // Middleware to serve static files
            // UseStaticFiles must come before UseMvcWithDefaultRoute to short circuit request pipeline.
            app.UseStaticFiles();

            // addomg MVC middleware tp Requestion pipeline
            app.UseMvcWithDefaultRoute();

            // using file server middleware
            //fileserveroptions fileserveroptions = new fileserveroptions();
            //fileserveroptions.defaultfilesoptions.defaultfilenames.clear();
            //fileserveroptions.defaultfilesoptions.defaultfilenames.add("foo.html");


            //app.UseFileServer(fileServerOptions);

            //app.UseFileServer();
                                 
            // Middleware
            app.Run(async (context) =>
            {
                //throw new Exception("Some error in processing request");
                await context.Response.WriteAsync("Hellow World");
            });
        }
    }
}
