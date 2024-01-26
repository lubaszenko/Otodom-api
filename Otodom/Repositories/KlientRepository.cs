using Microsoft.EntityFrameworkCore;
using Otodom.Models;
using Otodom.DTO;

namespace Otodom.Repositories
{
    public interface IKlientRepository
    {
        public Task<List<Klient>> GetKlient();
        public Task<Klient> PostKlient(KlientRequest KlientToAdd);
    }
    public class KlientRepository : IKlientRepository
    {
        private readonly OtodomContext _context;

        public async Task<List<Klient>> GetKlient()
        {
            return await _context.Klients.ToListAsync();
        }

        public async Task<Klient> PostKlient(KlientRequest KlientToAdd)
        {
            var klient = new Klient
            {
                Imie = KlientToAdd.Imie,
                Nazwisko = KlientToAdd.Nazwisko,
                Email = KlientToAdd.Email,
                NrTelefonuKlienta = KlientToAdd.NrTelefonuKlienta,
                AgencjaIdAgencji = KlientToAdd.AgencjaIdAgencji,
            };
            await _context.Klients.AddAsync(klient);
            await _context.SaveChangesAsync();
            return klient;
        }
    }
}
