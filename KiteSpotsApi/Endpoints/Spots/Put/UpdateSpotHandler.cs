using Common.Interface;
using DataAccess.Entities;
using FastEndpoints;

namespace KiteSpotsApi.Endpoints.Spots.Put;

public class UpdateSpotHandler(ISpotService<Spot> repo) : Endpoint<Spot, Spot>
{
    public override void Configure()
    {
        Put("/kite/spots");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Spot spot,CancellationToken ct)
    {
        SendAsync(await repo.UpdateSpot(spot), cancellation: ct);
    }
}