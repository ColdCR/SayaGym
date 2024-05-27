using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
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

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => 
    {
        options.LoginPath = "/Login/login";
        options.LogoutPath = "/Login/logout";
    });
builder.Services.AddHttpContextAccessor();

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

