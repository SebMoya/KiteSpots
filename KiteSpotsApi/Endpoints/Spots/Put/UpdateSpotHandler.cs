﻿using Common.Interface;
using DataAccess.Entities;
using FastEndpoints;

namespace KiteSpotsApi.Endpoints.Spots.Put;

public class UpdateSpotHandler(ISpotService<Spot> repo) : Endpoint<int, Spot>
{
    public override void Configure()
    {
        Get("/kite/spots");
        AllowAnonymous();
    }


    public override async Task HandleAsync(int req, CancellationToken ct)
    {
        var spots = await repo.GetAllSpots();

        var selectedSpot = spots.FirstOrDefault(x => x.Id == req);

        SendAsync(selectedSpot, cancellation: ct);
    }
{
    
}