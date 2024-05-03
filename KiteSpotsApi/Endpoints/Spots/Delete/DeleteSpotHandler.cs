using Common.Interface;
using DataAccess.Entities;
using FastEndpoints;

namespace KiteSpotsApi.Endpoints.Spots.Delete;

public class DeleteSpotHandler(ISpotService<Spot> repo) : Endpoint<int, bool>
{
    public override void Configure()
    {
        Delete("/kite/spots");
        AllowAnonymous();
    }


    public override async Task HandleAsync(int req, CancellationToken ct)
    {
        var spots = await repo.GetAllSpots();

        var selectedSpot = spots.FirstOrDefault(x => x.Id == req);

        if (selectedSpot is null)
        {
            SendAsync(false, cancellation: ct);
        }

        await repo.DeleteSpot(req);
        SendAsync(true, cancellation: ct);
    }
}