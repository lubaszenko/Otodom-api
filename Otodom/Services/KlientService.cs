using Otodom.DTO;
using Otodom.Models;
using Otodom.Repositories;

namespace Otodom.Services
{
    public interface IKlientService
    {
        public Task<List<Klient>> GetKlient();
        public Task<Klient> PostKlient(KlientRequest KlientToAdd);
    }
    public class KlientService : IKlientService
    {
        private readonly IKlientRepository _klientRepository;

        public KlientService(IKlientRepository klientRepository)
        {
            _klientRepository = klientRepository;
        }

        public async Task<List<Klient>> GetKlient()
        {
            var Klient = await _klientRepository.GetKlient();
            if (!Klient.Any())
                throw new Exception("Nie ma żadnego klienta.");
            return Klient;
        } 

        public async Task<Klient> PostKlient(KlientRequest KlientToAdd)
        {
            if (KlientToAdd.NrTelefonuKlienta < 10000000 || KlientToAdd.NrTelefonuKlienta > 99999999)
            {
                throw new Exception("Numer telefonu musi składać się z 8 znaków.");
            }

            if (!KlientToAdd.Email.Contains("@"))
            {
                throw new Exception("Email musi zawierac znak '@'.");
            }
            return await _klientRepository.PostKlient(KlientToAdd);
        }
    }
}
