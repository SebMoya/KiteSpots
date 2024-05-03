namespace Common.Interface;

public interface ISpotService<T> where T : class
{
    Task <IEnumerable<T>> GetAllSpots();
    Task <T> GetOneSpot(int id);
    Task <T> CreateSpot(T newSpot);
    Task <bool> DeleteSpot(int id);
    Task <T> UpdateSpot(T updatedSpot);
}