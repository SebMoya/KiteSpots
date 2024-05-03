using Common.Interface;
using DataAccess.Entities;
using FastEndpoints;

namespace KiteSpotsApi.Endpoints.Spots.Post;

public class CreateSpotHandler(ISpotService<Spot> repo) : Endpoint<Spot, Spot>
{
    public override void Configure()
    {
        Post("/kite/spots");
        AllowAnonymous();
    }


    public override async Task HandleAsync(Spot req, CancellationToken ct)
    {
       var success = await repo.CreateSpot(req);

        SendAsync(success, cancellation: ct);
    }
}