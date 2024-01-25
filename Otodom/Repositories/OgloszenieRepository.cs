using Microsoft.EntityFrameworkCore;
using Otodom.Models;
using Otodom.DTO;

namespace Otodom.Repositories
{
    public interface IOgloszenieRepository
    {
        public Task<List<Ogloszenie>> GetOgloszenie();
        public Task<Ogloszenie> DeleteOgloszenies(Ogloszenie OgloszenieToDelete);
    }

    public class OgloszenieRepository : IOgloszenieRepository
    {
        private readonly OtodomContext _context;

        public OgloszenieRepository(OtodomContext context)
        {
            _context = context;
        }
        public async Task<List<Ogloszenie>> GetOgloszenie()
        {
            return await _context.Ogloszenies
                .Include(n => n.NieruchomoscIdNieruchomosciNavigation)
                .Include(n => n.NieruchomoscIdNieruchomosciNavigation.Zdjecies)
                .ToListAsync();
        }
        public async Task<Ogloszenie> DeleteOgloszenies(Ogloszenie OgloszenieToDelete)
        {
            _context.Ogloszenies.Remove(OgloszenieToDelete);
            await _context.SaveChangesAsync();
            return OgloszenieToDelete;
        }
    }
}
