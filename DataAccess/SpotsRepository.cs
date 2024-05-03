using Common.Interface;
using DataAccess.Entities;

namespace DataAccess;

public class SpotsRepository(KiteSpotsDbContext _context) : ISpotService<Spot>
{
    
}