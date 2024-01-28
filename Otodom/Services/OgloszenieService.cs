using Otodom.DTO;
using Otodom.Models;
using Otodom.Repositories;

namespace Otodom.Services
{
    public interface IOgloszenieService
    {
        public Task<List<OgloszenieResponse>> GetOgloszenie();
        public Task<OgloszenieResponse> GetOgloszenie(int id);
        public Task<Ogloszenie> DeleteOgloszenies(int id);
        public Task<OgloszenieResponse> PostOgloszenie(OgloszenieRequest OgloszenieToAdd);
    }

    public class OgloszenieService : IOgloszenieService
    {
        private readonly IOgloszenieRepository _ogloszenieRepository;
        private readonly INieruchomoscService _nieruchomoscService;
        private readonly IZdjecieService _zdjecieService;

        public OgloszenieService(IOgloszenieRepository ogloszenieRepository)
        {
            _ogloszenieRepository = ogloszenieRepository;
        }

        public async Task<List<OgloszenieResponse>> GetOgloszenie()
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

        public async Task<OgloszenieResponse> PostOgloszenie(OgloszenieRequest OgloszenieToAdd)
        {
            if (OgloszenieToAdd.Opis is null)
                throw new Exception("Wprowadź opis ogłoszenia.");
            await _nieruchomoscService.GetNieruchomoscs(OgloszenieToAdd.NieruchomoscIdNieruchomosci);
            var ogloszenie = await _ogloszenieRepository.PostOgloszenie(OgloszenieToAdd);
            return await GetOgloszenie(ogloszenie.IdOgloszenia);
        }

        public async Task<OgloszenieResponse> GetOgloszenie(int id)
        {
            var Ogloszenia = await _ogloszenieRepository.GetOgloszenie(id);
            if (Ogloszenia == null)
                throw new Exception(String.Format("Nie ma ogłoszenia o {0}.", id));
            return Ogloszenia;
        }
    }
}
