using GestionHotel.Apis.Models;

namespace GestionHotel.Apis.Infrastructure.Repository.Interfaces;

public interface IChambreRepository
{
    Chambre GetChambreById(int id);
    
    Boolean IsChambreDisponible(int id, DateTime debut, DateTime fin);
    IEnumerable<Chambre> GetChambresDisponibles(DateTime debut, DateTime fin);

}