using GestionHotel.Apis.Infrastructure.Repository;
using GestionHotel.Apis.Infrastructure.Repository.Interfaces;
using GestionHotel.Apis.Models;
using GestionHotel.Apis.Services.Interfaces;

namespace GestionHotel.Apis.Services
{
    public class ChambreService : IChambreService
    {
        private readonly IChambreRepository _chambreRepository;

        public ChambreService(IChambreRepository chambreRepository)
        {
            _chambreRepository = chambreRepository;
        }

        public Chambre GetChambreById(int id)
        {
            return _chambreRepository.GetChambreById(id);
        }
        
        public bool IsChambreDisponible(int id, DateTime debut, DateTime fin)
        {
            return _chambreRepository.IsChambreDisponible(id, debut, fin);
        }
    }
}