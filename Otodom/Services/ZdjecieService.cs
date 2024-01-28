using Otodom.DTO;
using Otodom.Models;
using Otodom.Repositories;

namespace Otodom.Services
{
    public interface IZdjecieService
    {
        public Task<List<Zdjecie>> GetPhoto();
    }
    public class ZdjecieService : IZdjecieService
    {
        private readonly IZdjecieRepository _zdjecieRepository;

        public ZdjecieService(IZdjecieRepository zdjecieRepository)
        {
            _zdjecieRepository = zdjecieRepository;
        }

        public async Task<List<Zdjecie>> GetPhoto()
        {
            var Zdjecia = await _zdjecieRepository.GetPhoto();
            if (!Zdjecia.Any())
                throw new Exception("Nie ma żadnego zdjęcia.");
            return Zdjecia;
        }
    }
}