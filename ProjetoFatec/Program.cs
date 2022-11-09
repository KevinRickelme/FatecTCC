using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using ProjetoFatec.Data;
using ProjetoFatec.Interfaces;
using ProjetoFatec.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddEntityFrameworkSqlServer().AddDbContext<ApplicationContext>(o=>o.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

builder.Services.AddAuthentication(options => 
                     {
                         options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                     })
                     .AddCookie(options =>
                     {
                         options.LoginPath = "/login-microsoft";
                         options.AccessDeniedPath = "/Error/AccessDenied";

                     })
                     .AddMicrosoftAccount(mopt =>
                     {
                         mopt.ClientId = "51829ae1-66c7-4f3f-9e64-f949cff32bf3";
                         mopt.ClientSecret = "qTQ8Q~ZEv-TA-aJGpAb_ap5vO5HIur~Tjsom0aiK";
                     });

builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();


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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Usuario}/{action=Index}/{id?}");

app.Run();
