using GestionHotel.Apis.Models;

namespace GestionHotel.Apis.Services
{
    public class NotificationService : INotificationService
    {
        public void EnvoyerNotification(string destinataire, string message)
        {
            // Logique d'envoi de notification par email ou SMS
        }
    }
}