using GestionHotel.Apis.Models;
using GestionHotel.Models;

namespace GestionHotel.Apis.Services.Interfaces
{
    public interface IReservationService
    {
        Reservation ReserverChambre(Client client, Chambre chambre, DateTime debut, DateTime fin, string numeroCarteCredit);
        void AnnulerReservation(Reservation reservation);
        List<Chambre> GetChambresDisponibles(DateTime debut, DateTime fin);
        void AddReservationObserver(IObserver<Reservation> observer);
        void RemoveReservationObserver(IObserver<Reservation> observer);
        
    }
}
