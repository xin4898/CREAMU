﻿//connect core and model
using Microsoft.EntityFrameworkCore;
using m0611.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//get connect to sql in json data
builder.Services.AddDbContext<endtest0611Context>
(
    options => options.UseSqlServer
    (
        builder.Configuration.GetConnectionString
        (
            "endtest0611"
        )
    )
);
//sesstion
//builder.Services.AddSession(options => {
//    options.IdleTimeout = TimeSpan.FromMinutes(1);
//});
//builder.Services.AddMvc();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//use sesstion
//app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    //pattern: "{controller=Home}/{action=Index}/{id?}");
    pattern: "{controller=Home}/{action=Cart1}/{id?}");





app.Run();
