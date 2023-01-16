using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using DemoDMS.Data;
using System.Globalization;

CultureInfo.DefaultThreadCurrentCulture
= CultureInfo.DefaultThreadCurrentUICulture
= PersianDateExtensionMethods.GetPersianCulture();

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DemoDMSContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DemoDMSContext") ?? throw new InvalidOperationException("Connection string 'DemoDMScnt' not found.")));

builder.Services.AddPortableObjectLocalization();

builder.Services.Configure<RequestLocalizationOptions>(options => options
        .AddSupportedCultures("fa")
        .AddSupportedUICultures("fa"));

builder.Services.AddMvc().AddViewLocalization();

builder.Services.AddDbContext<DemoDMSContext>(
    options => options.UseSqlite(
        builder.Configuration.GetConnectionString("DemoDMSContext")
        ?? throw new InvalidOperationException("Connection string 'DemoDMSContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseRequestLocalization();

app.MapRazorPages();

app.Run();
