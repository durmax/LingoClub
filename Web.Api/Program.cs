using Application;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddInfrastructure();
builder.Services.AddApplication();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddCors();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.MapControllers();

//app.UseCors(policy =>
//    policy.AllowAnyOrigin()
//          .AllowAnyMethod()
//          .AllowAnyHeader());

app.UseHttpsRedirection();

app.Run();