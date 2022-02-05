/*
dotnet dev-certs https --trust
dotnet add package Microsoft.entityFrameworkCore.Relational
dotnet add package Microsoft.entityFrameworkCore.SqlServer
dotnet add package Microsoft.entityFrameworkCore.Tools
dotnet add package Microsoft.entityFrameworkCore.Tools.DotNet
dotnet add package Swashbuckle.AspNetCore

*/
using Microsoft.EntityFrameworkCore;
using RedeConcessionarias.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<RedeConcessionariaContext>();

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
