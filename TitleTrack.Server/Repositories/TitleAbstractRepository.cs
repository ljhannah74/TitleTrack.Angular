using Microsoft.EntityFrameworkCore;
using TitleTrack.Server.Data;
using TitleTrack.Server.Models;

namespace TitleTrack.Server.Repositories
{
    public class TitleAbstractRepository : ITitleAbstractRepository
    {
        private readonly AppDbContext _context;
        public TitleAbstractRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddTitleAbstractAsync(TitleAbstract titleAbstract)
        {
            _context.TitleAbstracts.Add(titleAbstract);
            await _context.SaveChangesAsync();    
        }

        public async Task DeleteTitleAbstractAsync(int id)
        {
            var employeeInDb = await _context.TitleAbstracts.FindAsync(id);
            if (employeeInDb == null)
            {
                throw new KeyNotFoundException($"TitleAbstract with ID {id} was not found.");
            }

            _context.TitleAbstracts.Remove(employeeInDb);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TitleAbstract>> GetAllTitleAbstractsAsync()
        {
            return await _context.TitleAbstracts.ToListAsync();
        }

        public async Task<TitleAbstract?> GetTitleAbstractByIdAsync(int id)
        {
            return await _context.TitleAbstracts.FindAsync(id);
        }

        public async Task UpdateTitleAbstractAsync(TitleAbstract titleAbstract)
        {

            _context.TitleAbstracts.Update(titleAbstract);
            await _context.SaveChangesAsync();
        }
    }
}
