using Common.Interface;
using DataAccess.Entities;
using FastEndpoints;

namespace KiteSpotsApi.Endpoints.Spots.Get.GetAllSpots;

public class GetAllSpotsHandler(ISpotService<Spot> repo) : Endpoint<EmptyRequest, IEnumerable<Spot>>
{
    public override void Configure()
    {
        Get("/kite/spots");
        AllowAnonymous();
    }

    public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
    {
        var spots = await repo.GetAllSpots();

        SendAsync(spots, cancellation: ct);
    }
}