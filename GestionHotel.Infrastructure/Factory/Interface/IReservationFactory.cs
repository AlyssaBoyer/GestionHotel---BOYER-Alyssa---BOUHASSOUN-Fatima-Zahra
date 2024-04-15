using GestionHotel.Apis.Models

namespace GestionHotel.Infrastructure.Factory.Interface
{
    public interface IReservationFactory
    {
        Reservation CreateReservation(Client client, Chambre chambre, DateTime debut, DateTime fin, string numeroCarteCredit);
    }
}