using FutureNHS.Api.Configuration;
using GPConnect.Provider.AcceptanceTests.Helpers;
using GPMigratorApp.GPConnect;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
var settings = builder.Configuration;
// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.Configure<AppSettings>(settings.GetSection("AppSettings"));

builder.Services.AddScoped<IJwtHelper>(
    sp =>
    {

        var config = sp.GetRequiredService<IOptionsSnapshot<AppSettings>>().Value;
        return new JwtHelper(config);
    });

//builder.Services.AddScoped<IJwtHelper, JwtHelper>();
builder.Services.AddScoped<IGPConnectService, GPConnectService>();
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
