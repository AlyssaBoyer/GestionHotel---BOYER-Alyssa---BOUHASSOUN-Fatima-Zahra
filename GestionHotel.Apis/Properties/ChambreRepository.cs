using GestionHotel.Apis.Models;

namespace GestionHotel.Infrastructure.Repository
{
    public interface IChambreRepository
    {
        Chambre GetChambreById(int id);
        // Autres méthodes de manipulation des données des chambres
    }

    public class ChambreRepository : IChambreRepository
    {
        // Implémentation de l'accès aux données des chambres
    }
}