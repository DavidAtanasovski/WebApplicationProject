using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApplicationProject.Data;
using WebProjectData;

namespace WebApplicationProject
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
            services.AddMvc();
            services.AddDbContextPool<WebProjectDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("WebProjectDb")));
            services.AddRazorPages();
           //services.AddSingleton<IChampData, ChampDataMemory>();
           services.AddScoped<IChampData, ChampionDataSql>();
           services.AddScoped<iPlayerSupport, PlayerSupportSql>();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
            });
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddDefaultTokenProviders()
                .AddDefaultUI()
                .AddEntityFrameworkStores<WebApplicationProjectContext>();
            services.AddAuthorization(options => { options.AddPolicy("RequireAdministratorRole", policy => policy.RequireRole("Admin")); });

            services.AddRazorPages().AddRazorPagesOptions(op =>
            {
                op.Conventions.AuthorizeFolder("/Champions", "RequireAdministratorRole");
                op.Conventions.AllowAnonymousToPage("/Champions/List");
                op.Conventions.AllowAnonymousToPage("/Champions/Detail");
                op.Conventions.AuthorizePage("/PlayerSupport/Detail", "RequireAdministratorRole");
                op.Conventions.AuthorizePage("/PlayerSupport/List", "RequireAdministratorRole");


            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
               
            }

            
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                
            });

           
        }
    }
}
