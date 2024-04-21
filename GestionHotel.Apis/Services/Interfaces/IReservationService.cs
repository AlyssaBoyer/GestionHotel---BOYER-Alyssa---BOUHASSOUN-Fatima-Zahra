using GestionHotel.Apis.Models;

namespace GestionHotel.Apis.Services.Interfaces
{
    public interface IReservationService
    {
        Reservation ReserverChambre(int clientId, int chambreId, DateTime debut, DateTime fin,
            string numeroCarteCredit, string username, string password);
        void AnnulerReservation(Reservation reservation, string userId);
        Reservation GetReservationById(int id);
        void GererArrivee(int reservationId, string userId);
        void GererDepart(int reservationId, string userId);

    }
}
