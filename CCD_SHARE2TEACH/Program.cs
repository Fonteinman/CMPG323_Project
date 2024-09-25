using CCD_SHARE2TEACH.Models;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
/*
// Add services to the container rolesDBContext
builder.Services.AddDbContext<RolesDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("StudentContext")));*/

// Add services to the container rolesDBContext
builder.Services.AddDbContext<RolesDbContext>(options =>
options.UseMySQL(builder.Configuration.GetConnectionString("StudentContext")));



// Add services to the container.

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
