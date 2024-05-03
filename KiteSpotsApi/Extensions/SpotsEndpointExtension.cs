using Common.Interface;
using DataAccess.Entities;

namespace KiteSpotsApi.Extensions;

public static class SpotsEndpointExtension
{
    public static IEndpointRouteBuilder MapSpotEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/spots", async (ISpotService<Spot> repo) => await repo.GetAllSpots());

        app.MapGet("/spots/{id}", async (ISpotService<Spot> repo, int id) =>
        {
            var spot = await repo.GetOneSpot(id);
            if (spot is null)
            {
                return Results.NotFound();
            }
            return Results.Ok(spot);
        });

        app.MapPost("/spots", async (ISpotService<Spot> repo, Spot spot) =>
        {
            await repo.CreateSpot(spot);
            return Results.Created($"spots/{spot.Id}", spot);
        });

        app.MapPut("/spots/{id}", async (ISpotService<Spot> repo, int id, Spot spot) =>
        {
            var addedSpot = await repo.UpdateSpot(spot);

            if (addedSpot is null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(addedSpot);
        });

        app.MapDelete("/spots/{id}", async (ISpotService<Spot> repo, int id) =>
        {
            var success = await repo.DeleteSpot(id);
            if (success == false)
            {
                return Results.NotFound();
            }
            return Results.Ok(success);
        });

        return app;
    }   
}