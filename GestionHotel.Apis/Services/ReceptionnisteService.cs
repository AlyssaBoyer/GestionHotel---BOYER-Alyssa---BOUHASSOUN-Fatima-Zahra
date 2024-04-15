using GestionHotel.Apis.Models;

namespace GestionHotel.Apis.Services
{
    public class ReceptionnisteService
    {
        private readonly ReservationService _reservationService;

        public ReceptionnisteService(ReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        public void GestionArrivee(Client client, Chambre chambre)
        {
            // Logique de gestion de l'arrivée du client
        }

        public void GestionDepart(Client client, Chambre chambre)
        {
            // Logique de gestion du départ du client
        }
    }
}