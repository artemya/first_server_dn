using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace first_server_dn
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public string RandElement(string[] array)
        {
            var rand = new Random();
            int randomElement = rand.Next(0, array.Length);
            return array[randomElement];
        }

        public string[] who = {"Шрек", "Осёл", "Кот в сапогах"};
        public string[] how = {"ужасно", "харизматично", "по дурацки"};
        public string[] does = {"рычит", "танцует", "бьет"};
        public string[] what = {"танго", "людей", "код"};

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {  
                endpoints.MapGet("/", async context =>
                {
                    context.Response.ContentType = "text/html; charset=utf-8";
                    context.Response.Headers.Add("InCamp-Student", "ArtemYa");
                    await context.Response.WriteAsync("Hello");
                });
                endpoints.MapGet("/who", async context =>
                {
                    context.Response.ContentType = "text/html; charset=utf-8";
                    // context.Response.Headers.Add("InCamp-Student", "ArtemYa");
                    await context.Response.WriteAsync(RandElement(who));
                });

                endpoints.MapGet("/how", async context =>
                {
                    context.Response.ContentType = "text/html; charset=utf-8";
                    // context.Response.Headers.Add("InCamp-Student", "ArtemYa");
                    await context.Response.WriteAsync(RandElement(how));
                });

                endpoints.MapGet("/does", async context =>
                {
                    context.Response.ContentType = "text/html; charset=utf-8";
                    // context.Response.Headers.Add("InCamp-Student", "ArtemYa");
                    await context.Response.WriteAsync(RandElement(does));
                });

                endpoints.MapGet("/what", async context =>
                {
                    context.Response.ContentType = "text/html; charset=utf-8";
                    // context.Response.Headers.Add("InCamp-Student", "ArtemYa");
                    await context.Response.WriteAsync(RandElement(what));
                });

                endpoints.MapGet("/quote", async context =>
                {
                    context.Response.ContentType = "text/html; charset=utf-8";
                    // context.Response.Headers.Add("InCamp-Student", "ArtemYa");
                    await context.Response.WriteAsync($"{RandElement(who)} {RandElement(how)} {RandElement(does)} {RandElement(what)}");
                });
                
                endpoints.MapGet("/incamp18-quote", async context =>
                {   
                    context.Response.ContentType = "text/html; charset=utf-8";
                    // context.Response.Headers.Add("InCamp-Student", "ArtemYa");
                    var word = new Words();
                    word.SetStrategy(new WithoutOptimization());

                    await context.Response.WriteAsync(word.GetHeaderInfoStrategy()); 
                });

                endpoints.MapGet("/incamp18-quote/optimization", async context =>
                {   
                    context.Response.ContentType = "text/html; charset=utf-8";
                    // context.Response.Headers.Add("InCamp-Student", "ArtemYa");
                    var word = new Words();
                    word.SetStrategy(new WithOptimization());

                    await context.Response.WriteAsync(word.GetHeaderInfoStrategy().ToString()); 
                });

            });
        }
    }
}
