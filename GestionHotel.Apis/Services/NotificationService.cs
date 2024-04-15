namespace GestionHotel.Apis.Services
{
    public interface INotificationService
    {
        void EnvoyerNotification(string destinataire, string message);
    }

    public class NotificationService : INotificationService
    {
        public void EnvoyerNotification(string destinataire, string message)
        {
            // Logique d'envoi de notification par email ou SMS
        }
    }
}