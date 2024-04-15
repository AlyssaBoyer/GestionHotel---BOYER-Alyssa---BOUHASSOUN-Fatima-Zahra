using GestionHotel.Apis.Models;

namespace GestionHotel.Apis.Services
{
    public interface IReservationService
    {
        Reservation ReserverChambre(Chambre chambre, DateTime debut, DateTime fin, string numeroCarteCredit);
        void AnnulerReservation(Reservation reservation);
    }

    public class ReservationService : IReservationService
    {
        private readonly ReservationRepository _reservationRepository;
        private readonly PaiementService _paiementService;

        public ReservationService(ReservationRepository reservationRepository, PaiementService paiementService)
        {
            _reservationRepository = reservationRepository;
            _paiementService = paiementService;
        }

        public Reservation ReserverChambre(Chambre chambre, DateTime debut, DateTime fin, string numeroCarteCredit)
        {
            // Logique de réservation
        }

        public void AnnulerReservation(Reservation reservation)
        {
            // Logique d'annulation de réservation
        }
    }
}