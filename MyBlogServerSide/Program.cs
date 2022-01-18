using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using MyBlog.Data;
using MyBlog.Data.Interfaces;
using MyBlogServerSide.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDbContextFactory<MyBlogDbContext>(opt => 
        opt.UseSqlite("Data Source=../MyBlog.db"));

builder.Services.AddScoped<IMyBlogApi, MyBlogApiServerSide>();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();

app.Services.GetService<IDbContextFactory<MyBlogDbContext>>()?.CreateDbContext().Database.Migrate();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();