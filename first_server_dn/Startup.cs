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

        public static string hostLine = Environment.GetEnvironmentVariable("HOSTS");


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var word = new Words();

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
                    await context.Response.WriteAsync("Hello" + hostLine);
                });
                endpoints.MapGet("/who", async context =>
                {
                    context.Response.ContentType = "text/html; charset=utf-8";
                    context.Response.Headers.Add("InCamp-Student", Environment.GetEnvironmentVariable("HOSTNAME"));
                    await context.Response.WriteAsync(word.RandomElement(who));
                });

                endpoints.MapGet("/how", async context =>
                {
                    context.Response.ContentType = "text/html; charset=utf-8";
                    context.Response.Headers.Add("InCamp-Student", Environment.GetEnvironmentVariable("HOSTNAME"));
                    await context.Response.WriteAsync(word.RandomElement(how));
                });

                endpoints.MapGet("/does", async context =>
                {
                    context.Response.ContentType = "text/html; charset=utf-8";
                    context.Response.Headers.Add("InCamp-Student", Environment.GetEnvironmentVariable("HOSTNAME"));
                    await context.Response.WriteAsync(word.RandomElement(does));
                });

                endpoints.MapGet("/what", async context =>
                {
                    context.Response.ContentType = "text/html; charset=utf-8";
                    context.Response.Headers.Add("InCamp-Student", Environment.GetEnvironmentVariable("HOSTNAME"));
                    await context.Response.WriteAsync(word.RandomElement(what));
                });

                endpoints.MapGet("/quote", async context =>
                {
                    context.Response.ContentType = "text/html; charset=utf-8";
                    context.Response.Headers.Add("InCamp-Student", Environment.GetEnvironmentVariable("HOSTNAME"));
                    await context.Response.WriteAsync($"{word.RandomElement(who)} {word.RandomElement(how)} {word.RandomElement(does)} {word.RandomElement(what)}");
                });
                
                endpoints.MapGet("/incamp18-quote", async context =>
                {   
                    context.Response.ContentType = "text/html; charset=utf-8";
                    
                    word.SetStrategy(new WithoutOptimization());

                    await context.Response.WriteAsync(word.GetHeaderInfoStrategy()); 
                });

                endpoints.MapGet("/incamp18-quote/optimization", async context =>
                {   
                    context.Response.ContentType = "text/html; charset=utf-8";
                    
                    word.SetStrategy(new WithOptimization());

                    await context.Response.WriteAsync(word.GetHeaderInfoStrategy()); 
                });

            });
        }
    }
}
