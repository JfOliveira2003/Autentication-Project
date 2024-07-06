using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BankMvc.Data;
using BankMvc.Models;


var builder = WebApplication.CreateBuilder(args);

//Adding the services to the container.
builder.Services.AddRazorPages();

var connectionString = builder.Configuration.GetConnectionString("StrConn") ?? throw new InvalidOperationException("Connection string 'BankDbContextConnection' not found.");

builder.Services.AddDbContext<BankDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddDefaultIdentity<Employee>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<BankDbContext>();

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

app.Run();
