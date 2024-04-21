using GestionHotel.Apis.Models;

namespace GestionHotel.Apis.Services.Interfaces
{
    public interface INotificationService
    {
        void NotifierAnnulationTardive(Client client);
    }
}