using GestionHotel.Apis.Infrastructure.Repository;
using GestionHotel.Apis.Models;
using GestionHotel.Apis.Services.Interfaces;

namespace GestionHotel.Apis.Services
{
    public class ChambreService : IChambreService
    {
        private readonly ChambreRepository _chambreRepository;

        public ChambreService(ChambreRepository chambreRepository)
        {
            _chambreRepository = chambreRepository;
        }

        public Chambre GetChambreById(int id)
        {
            return _chambreRepository.GetChambreById(id);
        }

        public List<Chambre> GetChambresDisponibles(DateTime debut, DateTime fin)
        {
            return _chambreRepository.GetChambresDisponibles(debut, fin);
        }
        
        public bool IsChambreDisponible(int id, DateTime debut, DateTime fin)
        {
            return _chambreRepository.IsChambreDisponible(id, debut, fin);
        }
    }
}