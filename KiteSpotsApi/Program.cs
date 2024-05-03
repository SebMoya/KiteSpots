using Common.DTO;
using Common.Interface;
using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("KiteSpotsLocal");

builder.Services.AddScoped<ISpotService<Spot>, SpotsRepository>();

builder.Services.AddDbContext<KiteSpotsDbContext>(options =>
       options.UseSqlServer(connectionString));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
