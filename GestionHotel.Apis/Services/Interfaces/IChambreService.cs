using GestionHotel.Models;

namespace GestionHotel.Apis.Services.Interfaces
{
    public interface IChambreService
    {
        Chambre GetChambreById(int id);
        List<Chambre> GetChambresDisponibles(DateTime debut, DateTime fin);
    }
}