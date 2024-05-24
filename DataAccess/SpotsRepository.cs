using Common.Interface;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class SpotsRepository(KiteSpotsDbContext _context) : ISpotService<Spot>
{
    public async Task<IEnumerable<Spot>> GetAllSpots()
    {
        return await _context.Spots.ToListAsync();
    }

    public async Task<Spot> GetOneSpot(int id)
    {
        var spot = await _context.Spots.FirstOrDefaultAsync(x => x.Id == id);

        if (spot is null)
        {
            return null;
        }

        return spot;
    }

    public async Task<Spot> CreateSpot(Spot newSpot)
    {
        _context.Spots.Add(newSpot);
        //await _context.SaveChangesAsync();
        return newSpot;
    }

    public async Task<Spot> UpdateSpot(Spot updatedSpot)
    {
        var spot = await _context.Spots.FirstOrDefaultAsync(x => x.Id == updatedSpot.Id);
        if (spot == null)
        {
            return null;
        }

        spot.Name = updatedSpot.Name;
        spot.Description = updatedSpot.Description;
        spot.Properties = updatedSpot.Properties;
        spot.Image = updatedSpot.Image;
        spot.WindDirectionGood = updatedSpot.WindDirectionGood;
        spot.WindDirectionOk = updatedSpot.WindDirectionOk;
        spot.WindDirectionBad = updatedSpot.WindDirectionBad;
        spot.Latitude = updatedSpot.Latitude;
        spot.Longitude = updatedSpot.Longitude;
        spot.Area = updatedSpot.Area;
        spot.County = updatedSpot.County;

        //await _context.SaveChangesAsync();
        return spot;
    }

    public async Task<bool> DeleteSpot(int id)
    {
        var spot = await _context.Spots.FirstOrDefaultAsync(x => x.Id == id);
        if (spot == null)
        {
            return false;
        }
        _context.Spots.Remove(spot);
        //await _context.SaveChangesAsync();
        return true;
    }
}