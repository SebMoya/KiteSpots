using Common.DTO;
using Common.Interface;
using DataAccess;
using DataAccess.Entities;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("KiteSpotsLocal");

builder.Services.AddScoped<ISpotService<Spot>, SpotsRepository>();

builder.Services.AddDbContext<KiteSpotsDbContext>(options =>
       options.UseSqlServer(connectionString));

builder.Services.AddFastEndpoints();

var app = builder.Build();

app.UseFastEndpoints();

app.Run();
