using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using ProjetoFatec.Infra.Data.Context;
using ProjetoFatec.Infra.IoC;
using ProjetoFatec.MVC.MappingConfig;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddInfraestructure(builder.Configuration);

builder.Services.AddAutoMapperConfiguration();

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


var app = builder.Build();


using (IServiceScope scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var context = services.GetRequiredService<ApplicationContext>();
        context.Database.Migrate();
    }
    catch(Exception ex)
    {
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogError("Ocorreu um erro na migração ou alimentação dos dados. Ex => " + ex.Message + "\nStack => " + ex.StackTrace);
    }
}



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
