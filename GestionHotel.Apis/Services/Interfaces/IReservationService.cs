using GestionHotel.Apis.Models;

namespace GestionHotel.Apis.Services.Interfaces
{
    public interface IReservationService
    {
        Reservation ReserverChambre(int clientId, int chambreId, DateTime debut, DateTime fin,
            string numeroCarteCredit, string username, string password);
        void AnnulerReservation(Reservation reservation, string userId);
        Reservation GetReservationById(int id);
        void GererArrivee(Reservation reservation, string userId);
        void GererDepart(Reservation reservation, string userId);

    }
}
