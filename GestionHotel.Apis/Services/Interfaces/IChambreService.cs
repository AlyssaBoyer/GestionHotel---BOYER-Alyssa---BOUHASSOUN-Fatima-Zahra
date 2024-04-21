using GestionHotel.Apis.Models;

namespace GestionHotel.Apis.Services.Interfaces
{
    public interface IChambreService
    {
        Chambre GetChambreById(int id);
        bool IsChambreDisponible(int id, DateTime debut, DateTime fin);
    }
}