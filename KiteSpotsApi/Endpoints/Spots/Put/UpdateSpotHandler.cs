using Common.Interface;
using DataAccess.Entities;
using FastEndpoints;

namespace KiteSpotsApi.Endpoints.Spots.Put;

public class UpdateSpotHandler(ISpotService<Spot> repo) : Endpoint<int, Spot>
{
    public override void Configure()
    {
        Put("/kite/spots");
        AllowAnonymous();
    }

    public override async Task HandleAsync(int req, Spot spot,CancellationToken ct)
    {
        await repo.UpdateSpot

        SendAsync(await repo.UpdateSpot(req, spot), cancellation: ct);
    }
}