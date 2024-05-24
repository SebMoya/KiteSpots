using Common.Interface;
using DataAccess.Entities;

namespace DataAccess.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    SpotsRepository SpotService { get; }

    Task SaveChangesAsync();
}