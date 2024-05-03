using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class KiteSpotsDbContext : DbContext
{
    public DbSet<Spot> Spots { get; set; }

    public KiteSpotsDbContext(DbContextOptions options) : base(options)
    {
        
    }
}