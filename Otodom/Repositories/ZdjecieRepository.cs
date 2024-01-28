using Microsoft.EntityFrameworkCore;
using Otodom.Models;
using Otodom.DTO;

namespace Otodom.Repositories
{
    public interface IZdjecieRepository
    {
        public Task<List<Zdjecie>> GetPhoto();
    }
    public class ZdjecieRepository : IZdjecieRepository
    {
        private readonly OtodomContext _context;

        public ZdjecieRepository(OtodomContext context)
        {
            _context = context;
        }
        public async Task<List<Zdjecie>> GetPhoto()
        {
            return await _context.Zdjecies.ToListAsync();
        }
    }
}
