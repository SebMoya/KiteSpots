using Common.Interface;
using DataAccess.Entities;
using DataAccess.UnitOfWork;

namespace KiteSpotsApi.Extensions;

public static class SpotsEndpointExtension
{
    public static IEndpointRouteBuilder MapSpotEndpoints(this IEndpointRouteBuilder app)
    {
        //app.MapGet("/spots", async (ISpotService<Spot> repo) => await repo.GetAllSpots());
        app.MapGet("/spots", async (IUnitOfWork repo) => await repo.SpotService.GetAllSpots());


        //app.MapGet("/spots/{id}", async (ISpotService<Spot> repo, int id) =>
        app.MapGet("/spots/{id}", async (IUnitOfWork repo, int id) =>

    {
        var spot = await repo.SpotService.GetOneSpot(id);
        if (spot is null)
        {
            return Results.NotFound();
        }
        return Results.Ok(spot);
    });

        //app.MapPost("/spots", async (ISpotService<Spot> repo, Spot spot) =>
        app.MapPost("/spots", async (IUnitOfWork repo, Spot spot) =>

    {
        await repo.SpotService.CreateSpot(spot);
        await repo.SaveChangesAsync();
        return Results.Created($"spots/{spot.Id}", spot);
    });

        //app.MapPut("/spots/{id}", async (ISpotService<Spot> repo, int id, Spot spot) =>
        app.MapPut("/spots/{id}", async (IUnitOfWork repo, int id, Spot spot) =>

    {
        var addedSpot = await repo.SpotService.UpdateSpot(spot);

        if (addedSpot is null)
        {
            return Results.BadRequest();
        }

        await repo.SaveChangesAsync();
        return Results.Ok(addedSpot);
    });

        //app.MapDelete("/spots/{id}", async (ISpotService<Spot> repo, int id) =>
        app.MapDelete("/spots/{id}", async (IUnitOfWork repo, int id) =>

    {
        var success = await repo.SpotService.DeleteSpot(id);
        if (success == false)
        {
            return Results.NotFound();
        }
        await repo.SaveChangesAsync();
        return Results.Ok(success);
    });

        return app;
    }
}