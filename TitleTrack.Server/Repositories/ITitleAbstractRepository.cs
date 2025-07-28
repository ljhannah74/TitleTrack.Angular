using TitleTrack.Server.Models;

namespace TitleTrack.Server.Repositories
{
    public interface ITitleAbstractRepository
    {
        Task<IEnumerable<TitleAbstract>> GetAllTitleAbstractsAsync();
        Task<TitleAbstract> GetTitleAbstractByIdAsync(int id);
        Task AddTitleAbstractAsync(TitleAbstract titleAbstract);
        Task UpdateTitleAbstractAsync(TitleAbstract titleAbstract);
        Task DeleteTitleAbstractAsync(int id);
    }
}
