using Microsoft.EntityFrameworkCore;
using SayaGym.Data;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container.
builder.Services.AddControllersWithViews();

var StringConexion = builder.Configuration["StringConexionSecret"];
if (StringConexion == null)
{
    //usar la que viene en appsetings.json
    StringConexion = builder.Configuration.GetConnectionString("StringConexion");
}
//String de conexion
builder.Services.AddDbContext<SayaGym.Data.Contexto>(options => options.UseSqlServer(StringConexion));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

// ---------------- INICIO VERSION JOSE -------------------------
/* 
 
using Microsoft.AspNetCore.Hosting;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }
    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
        { webBuilder.UseStartup<SayaGym.Startup>(); });
    }
}*/
// ---------------- FIN VERSION JOSE -------------------------
