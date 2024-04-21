using MailKit.Net.Smtp;
using MimeKit;
using GestionHotel.Apis.Models;
using GestionHotel.Apis.Services.Interfaces;

namespace GestionHotel.Apis.Services
{
    public class NotificationService : INotificationService
    {
        public void NotifierAnnulationTardive(Client client)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Votre Nom", "votre@email.com"));
            message.To.Add(new MailboxAddress(client.Nom, client.Email));
            message.Subject = "Annulation de votre réservation";
            message.Body = new TextPart("plain")
            {
                Text = $"Bonjour {client.Nom},\n\nNous vous informons que votre réservation a été annulée moins de 24 heures avant la date d'arrivée prévue. Malheureusement, aucun remboursement ne sera effectué.\n\nCordialement,\nVotre hôtel"
            };

            using (var clientSmtp = new SmtpClient())
            {
                // Assurez-vous que les informations de connexion sont sécurisées et ne sont pas codées en dur
                clientSmtp.Connect("smtp.example.com", 587, false);
                clientSmtp.Authenticate("username", "password");
                clientSmtp.Send(message);
                clientSmtp.Disconnect(true);
            }
        }
    }
}