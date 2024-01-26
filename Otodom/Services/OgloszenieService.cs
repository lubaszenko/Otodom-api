using Otodom.DTO;
using Otodom.Models;
using Otodom.Repositories;

namespace Otodom.Services
{
    public interface IOgloszenieService
    {
        public Task<List<Ogloszenie>> GetOgloszenie();
        public Task<Ogloszenie> DeleteOgloszenies(int id);
        public Task<Ogloszenie> PostOgloszenie(OgloszenieRequest OgloszenieToAdd);
    }

    public class OgloszenieService : IOgloszenieService
    {
        private readonly IOgloszenieRepository _ogloszenieRepository;
        private readonly INieruchomoscService _nieruchomoscService;

        public OgloszenieService(IOgloszenieRepository ogloszenieRepository)
        {
            _ogloszenieRepository = ogloszenieRepository;
        }
        
        public async Task<List<Ogloszenie>> GetOgloszenie()
        {
            var Ogloszenia = await _ogloszenieRepository.GetOgloszenie();
            if (!Ogloszenia.Any())
                throw new Exception("Nie ma żadnego ogłoszenia.");
            return Ogloszenia;
        }
        public async Task<Ogloszenie> DeleteOgloszenies(int id)
        {
                if (id <= 0)
                    throw new Exception("Podałeś ujemne id.");
                var OgloszenieToDelete = await DeleteOgloszenies(id);
                await _ogloszenieRepository.DeleteOgloszenies(OgloszenieToDelete);
                return OgloszenieToDelete;
        }

        public async Task<Ogloszenie> PostOgloszenie(OgloszenieRequest OgloszenieToAdd)
        {
            if (OgloszenieToAdd.Opis is null)
                throw new Exception("Wprowadź opis ogłoszenia.");
            await _nieruchomoscService.GetNieruchomoscs(OgloszenieToAdd.NieruchomoscIdNieruchomosci);
            return await _ogloszenieRepository.PostOgloszenie(OgloszenieToAdd);
        }
    }
}
