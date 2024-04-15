namespace GestionHotel.Apis.Services.Interfaces
{
    public interface INotificationService
    {
        void EnvoyerNotification(string destinataire, string message);
    }
}