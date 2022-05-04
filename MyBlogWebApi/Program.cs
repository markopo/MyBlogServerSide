using System.Reflection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyBlog.Data;
using MyBlog.Data.Interfaces;
using MyBlogWebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddDbContextFactory<MyBlogDbContext>(opt => 
        opt.UseSqlite("Data Source=../MyBlog.db"));

builder.Services.AddScoped<IMyBlogApi, MyBlogApiServerSide>();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddTransient<INotifierMediatorService, NotifierMediatorService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();