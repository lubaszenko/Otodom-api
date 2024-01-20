using Microsoft.EntityFrameworkCore;
using Otodom.Models;
using Otodom.DTO;

namespace Otodom.Repositories
{
    public interface INieruchomoscRepository
    {
        public Task<List<Nieruchomosc>> GetNieruchomoscs();
        public Task<Nieruchomosc> GetNieruchomoscs(int id);

        /*public Task<Nieruchomosc> GetNieruchomoscs(string miasto);*/
        public Task<Nieruchomosc> PostNieruchomosc(NieruchomoscRequest NieruchomoscToAdd);
        public Task<Nieruchomosc> DeleteNieruchomoscs(Nieruchomosc NieruchomoscToDelete);
    }
    public class NieruchomoscRepository : INieruchomoscRepository
    {
        private readonly OtodomContext _context;

        public NieruchomoscRepository(OtodomContext context)
        {
            _context = context;
        }

        public async Task<List<Nieruchomosc>> GetNieruchomoscs()
        {
            return await _context.Nieruchomoscs.ToListAsync();
        }
        public async Task<Nieruchomosc> GetNieruchomoscs(int id)
        {
            return await _context.Nieruchomoscs.Where(b => b.IdNieruchomosci == id).FirstOrDefaultAsync();
        }

        /*public async Task<Nieruchomosc> GetNieruchomoscs(string miasto)
        {
            return await _context.Nieruchomoscs.Where(a => a.Miasto == miasto).FirstOrDefaultAsync();
        }*/

        public async Task<Nieruchomosc> PostNieruchomosc(NieruchomoscRequest NieruchomoscToAdd)
        {
            var nieruchomosc = new Nieruchomosc
            {
                Wojewodztwo = NieruchomoscToAdd.Wojewodztwo,
                Miasto = NieruchomoscToAdd.Miasto,
                KodPocztowy = NieruchomoscToAdd.KodPocztowy,
                Ulica = NieruchomoscToAdd.Ulica,
                NrDomu = NieruchomoscToAdd.NrDomu,
                PowierzchniaDomu = NieruchomoscToAdd.PowierzchniaDomu,
                LiczbaPieter = NieruchomoscToAdd.LiczbaPieter,
                RokBudowy = NieruchomoscToAdd.RokBudowy,
                StanWykonczenia = NieruchomoscToAdd.StanWykonczenia,
                RodzajOkna = NieruchomoscToAdd.Wojewodztwo,
                TypOgrzewania = NieruchomoscToAdd.Wojewodztwo,
                RodzajZabudowy = NieruchomoscToAdd.Wojewodztwo,
            };
            await _context.Nieruchomoscs.AddAsync(nieruchomosc);
            await _context.SaveChangesAsync();
            return nieruchomosc;
        }

        public async Task<Nieruchomosc> DeleteNieruchomoscs(Nieruchomosc NieruchomoscToDelete)
        {
            _context.Nieruchomoscs.Remove(NieruchomoscToDelete);
            await _context.SaveChangesAsync();
            return NieruchomoscToDelete;
        }
    }
}