using GestionHotel.Apis.Models;

namespace GestionHotel.Infrastructure.Factory.Interface
{
    public class ReservationFactory : IReservationFactory
    {
        public Reservation CreateReservation(Client client, Chambre chambre, DateTime debut, DateTime fin, string numeroCarteCredit)
        {
            // Implémentation de la création d'une réservation
        }
    }
}
