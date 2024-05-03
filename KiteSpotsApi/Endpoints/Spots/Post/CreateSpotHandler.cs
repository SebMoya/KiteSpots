using Common.Interface;
using DataAccess.Entities;
using FastEndpoints;

namespace KiteSpotsApi.Endpoints.Spots.Post;

public class CreateSpotHandler(ISpotService<Spot> repo) : Endpoint<Spot, EmptyRequest>
{
    public override void Configure()
    {
        Put("/kite/spots");
        AllowAnonymous();
    }


    public override async Task HandleAsync(Spot req, CancellationToken ct)
    {
        await repo.CreateSpot(req);
    }
}