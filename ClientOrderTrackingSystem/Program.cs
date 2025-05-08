using System.Diagnostics.Metrics;
using System;
using Microsoft.EntityFrameworkCore;
using ClientOrderTrackingSystem.Models;
using ClientOrderTrackingSystem.Models.Repositorie;
//using smartGadgetsStore.Models;
//using smartGadgetsStore.Models.Repositorie;


var builder = WebApplication.CreateBuilder(args);

//Enable MVC IN project
builder.Services.AddControllersWithViews();



///////////////////DB/////////////////////////////////
///
IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").Build();

builder.Services.AddDbContext<AppDBContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("sqlCon"));
});

builder.Services.AddScoped<IRepositorie<Client>, dbClientRepositorie>();
builder.Services.AddScoped<IRepositorie<Order>, dbOrderRepositorie>();
builder.Services.AddScoped<IRepositorie<Payment>, dbPaymentRepositorie>();
builder.Services.AddScoped<IRepositorie<Product>, dbProductRepositorie>();
builder.Services.AddScoped<IRepositorie<User>, dbUserRepositorie>();
builder.Services.AddScoped<IRepositorie<UserType>, dbUserTypeRepositorie>();


////////////////////////////////////////////////////




var app = builder.Build();


//app.MapGet("/", () => "Hello World!");

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting(); // Controller/Action

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}"
    );


app.Run();
