/*
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SayaGym.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
namespace SayaGym
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            string conString;        

            services.AddDbContext<Contexto>(options =>
            {
                if (System.Environment.GetEnvironmentVariable("StringConexion") != null)
                {
                    conString = System.Environment.GetEnvironmentVariable("StringConexion");
                }
                else
                {
                    conString = Configuration.GetConnectionString("StringConexion");
                }
                options.UseSqlServer(conString);
            });

            services.AddScoped<Contexto>();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie();

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();
            app.UseEndpoints(endpoints => endpoints.MapControllerRoute(
                name: "default", pattern: "{controller=Home}/{action=Index}/{id?}"));
        }
    }
}
*/