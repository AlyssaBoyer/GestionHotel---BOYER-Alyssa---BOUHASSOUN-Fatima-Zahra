using GestionHotel.Apis.Infrastructure.Repository.Interfaces;
using GestionHotel.Apis.Models;

namespace GestionHotel.Apis.Infrastructure.Repository;

public class ChambreRepository : IChambreRepository
{
    public ChambreRepository(/* Dépendances nécessaires */)
    {
        //TODO : Initialisation de vos dépendances
    }

    public Chambre GetChambreById(int id)
    {
        Chambre chambre = new Chambre();
        // TODO :Implémentez la logique pour obtenir une chambre par son ID
        return chambre;
    }

    public List<Chambre> GetChambresDisponibles(DateTime debut, DateTime fin)
    {
        List<Chambre> Chambre = new     List<Chambre>();
        //TODO : Implémentez la logique pour obtenir les chambres disponibles
        return Chambre;
    }
    
    public Boolean IsChambreDisponible(int id, DateTime debut, DateTime fin)
    {
        // TODO :Implémentez la logique pour obtenir une chambre par son ID
        return true;
    }
}