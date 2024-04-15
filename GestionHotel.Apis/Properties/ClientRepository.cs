using GestionHotel.Apis.Models;

namespace GestionHotel.Infrastructure.Repository
{
    public interface IClientRepository
    {
        Client GetClientById(int id);
        // Autres méthodes de manipulation des données des clients
    }

    public class ClientRepository : IClientRepository
    {
        // Implémentation de l'accès aux données des clients
    }
}