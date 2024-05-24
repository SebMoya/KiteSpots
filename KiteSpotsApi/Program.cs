using Common.Interface;
using DataAccess;
using DataAccess.Entities;
using DataAccess.UnitOfWork;
using KiteSpotsApi.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("KiteSpotsLocal");

builder.Services.AddScoped<ISpotService<Spot>, SpotsRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddDbContext<KiteSpotsDbContext>(options =>
       options.UseSqlServer(connectionString));

var app = builder.Build();

app.MapSpotEndpoints();
app.Run();
