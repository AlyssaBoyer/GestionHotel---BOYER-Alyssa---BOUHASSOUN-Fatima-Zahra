using GestionHotel.Apis.Models;

namespace GestionHotel.Apis.Infrastructure.Repository.Interfaces;

public interface IChambreRepository
{
    Chambre GetChambreById(int id);
    List<Chambre> GetChambresDisponibles(DateTime debut, DateTime fin);
    
    Boolean IsChambreDisponible(int id, DateTime debut, DateTime fin);
}