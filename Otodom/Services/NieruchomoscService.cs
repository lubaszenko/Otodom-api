using Otodom.DTO;
using Otodom.Models;
using Otodom.Repositories;

namespace Otodom.Services
{
    public interface INieruchomoscService
    {
        public Task<List<Nieruchomosc>> GetNieruchomoscs();
        public Task<Nieruchomosc> GetNieruchomoscs(int id);

        /*public Task<Nieruchomosc> GetNieruchomoscs(string miasto);*/
        public Task<Nieruchomosc> PostNieruchomosc(NieruchomoscRequest NieruchomoscToAdd);
        public Task<Nieruchomosc> DeleteNieruchomoscs(int id);
    }
    public class NieruchomoscService : INieruchomoscService
    {
        private readonly INieruchomoscRepository _nieruchomoscRepository;

        public NieruchomoscService(INieruchomoscRepository nieruchomoscRepository)
        {
            _nieruchomoscRepository = nieruchomoscRepository;
        }

        public async Task<List<Nieruchomosc>> GetNieruchomoscs()
        {
            var Nieruchomosci = await _nieruchomoscRepository.GetNieruchomoscs();
            if (!Nieruchomosci.Any())
                throw new Exception("Nie ma żadnej nieruchomości.");
            return Nieruchomosci;
        }

        public async Task<Nieruchomosc> GetNieruchomoscs(int id)
        {
            if (id <= 0)
                throw new Exception("Podałeś ujemne id.");
            var Nieruchomosc = await _nieruchomoscRepository.GetNieruchomoscs(id);
            if (Nieruchomosc == null)
                throw new Exception(String.Format("Nie ma żadnej nieruchomości o id {0}.", id));
            return Nieruchomosc;
        }

        /*public async Task<Nieruchomosc> GetNieruchomoscs(string miasto)
        {
            var nieruchomosc = await _nieruchomoscRepository.GetNieruchomoscs(miasto);
            if (miasto == null)
                throw new Exception("Nie podano wartości dla miasta.");
            if (nieruchomosc == null)
                throw new Exception(String.Format("Nie znaleziono nieruchomości dla miasta o nazwie {0}.", miasto));
            return nieruchomosc;
        }*/

        public async Task<Nieruchomosc> PostNieruchomosc(NieruchomoscRequest NieruchomoscToAdd)
        {
            if (NieruchomoscToAdd.KodPocztowy < 10000 || NieruchomoscToAdd.KodPocztowy > 99999)
                throw new Exception("Podaj pełny kod pocztowy składający się z 5 cyfr.");
            return await _nieruchomoscRepository.PostNieruchomosc(NieruchomoscToAdd);
        }

        public async Task<Nieruchomosc> DeleteNieruchomoscs(int id)
        {
            if (id <= 0)
                throw new Exception("Podałeś ujemne id.");
            var NieruchomoscToDelete = await GetNieruchomoscs(id);
            if (NieruchomoscToDelete == null)
                throw new Exception("Nie znaleziono nieruchomości o identyfikatorze {id} do usunięcia.");
            await _nieruchomoscRepository.DeleteNieruchomoscs(NieruchomoscToDelete);
            return NieruchomoscToDelete;
        }
    }
}
