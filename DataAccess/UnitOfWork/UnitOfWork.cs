using Common.Interface;
using DataAccess.Entities;

namespace DataAccess.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly KiteSpotsDbContext _context;

    public SpotsRepository SpotService { get; private set; }

    public UnitOfWork(KiteSpotsDbContext context)
    {
        _context = context;
        SpotService = new SpotsRepository(_context);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
    public async void Dispose()
    {
        await _context.DisposeAsync();
    }
}