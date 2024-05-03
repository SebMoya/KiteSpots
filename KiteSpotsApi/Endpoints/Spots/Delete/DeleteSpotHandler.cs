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
        var result = await repo.DeleteSpot(req);

        SendAsync(result, cancellation: ct);
    }
}