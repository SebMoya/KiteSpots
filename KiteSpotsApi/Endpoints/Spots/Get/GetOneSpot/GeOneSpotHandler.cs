using Common.Interface;
using DataAccess.Entities;
using FastEndpoints;

namespace KiteSpotsApi.Endpoints.Spots.Get.GetOneSpot;

public class GeOneSpotHandler(ISpotService<Spot> repo) : Endpoint<int, Spot>
{
    public override void Configure()
    {
        Get("/kite/spots/");
        AllowAnonymous();
    }


    public override async Task HandleAsync(int req, CancellationToken ct)
    {
        SendAsync(await repo.GetOneSpot(req), cancellation: ct);
    }
}