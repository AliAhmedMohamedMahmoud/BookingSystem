using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BookingSystem.Models;

namespace BookingSystem
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime.
        // Use this method to add services to the container.ServiceProvider
        public void ConfigureServices(IServiceCollection services)
        {
         
            services.AddControllersWithViews();
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
            services.AddDbContext<Entity>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("cs"));
            });

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<Entity>();//register UserManager,RoleManger
           
        }

        // This method gets called by the runtime.
        // Use this method to configure the HTTP request pipeline.build response --Midlware
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            #region inline Middleware use run map
            //app.Use(async(context, next) => {
            //    await context.Response.WriteAsync("1)MiddleWare 1\n");
            //    await next.Invoke();//call next
            //    await context.Response.WriteAsync("1)MiddleWare 1\n");

            //});
            //app.Use(async (context, next) => {
            //    await context.Response.WriteAsync("2)MiddleWare 2\n");
            //    await next.Invoke();//response hang
            //    await context.Response.WriteAsync("2)MiddleWare 2\n");

            //});
            //app.Run(async (context) => { 
            //    await context.Response.WriteAsync("3)Terminate \n");


            //});//terminiate
            #endregion
            #region Middleware component
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();//get request url and math it with specific patter ex/department/index
            app.UseSession();
            
            app.UseAuthentication();//fiter authorize

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>//Defaine route templater "Pattern"
            //use any patter execute departmetncontoller ==>index
            {
                //Route attribute
                //MVC
                endpoints.MapControllerRoute(name:"MyRoute1",
                    pattern:"std/{name:alpha}/{age:int}/{id?}",
                    defaults: new {controller= "Route", action="Index" });//std/ahmed
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            
            #endregion
        }
    }
}
