using Microsoft.EntityFrameworkCore;
using entityFramework.Models;
using entityFramework.Data;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<UserDbContext>(options=>options.UseMySql(connectionString, new MySqlServerVersion(new Version(8,0,21))));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
