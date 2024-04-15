using GestionHotel.Apis.Models;

namespace GestionHotel.Apis.Services
{
    public class ReceptionnisteService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IChambreRepository _chambreRepository;
        private readonly PaiementService _paiementService;
        private readonly INotificationService _notificationService;

        public ReceptionnisteService(IReservationRepository reservationRepository, IChambreRepository chambreRepository, PaiementService paiementService, INotificationService notificationService)
        {
            _reservationService = reservationService;
            _reservationRepository = reservationRepository;
            _chambreRepository = chambreRepository;
            _paiementService = paiementService;
            _notificationService = notificationService;
        }
        public Reservation ReserverChambre(Chambre chambre, DateTime debut, DateTime fin, string numeroCarteCredit)
        {
            // Implémentation de la réservation spécifique au réceptionniste
            throw new NotImplementedException();
        }
        public void AnnulerReservation(Reservation reservation)
        {
            // Implémentation de l'annulation de réservation spécifique au réceptionniste
            throw new NotImplementedException();
        }
        public IEnumerable<Chambre> GetChambresDisponiblesAvecEtat(DateTime debut, DateTime fin)
        {
            // Implémentation pour obtenir la liste des chambres disponibles avec l'état général de la chambre
            throw new NotImplementedException();
        }
        public void GererArrivee(Reservation reservation)
        {
            // Implémentation pour gérer l'arrivée du client
            throw new NotImplementedException();
        }

        public void GererDepart(Reservation reservation)
        {
            // Implémentation pour gérer le départ du client
            throw new NotImplementedException();

        public void EnvoyerEmailPostSejour(Reservation reservation)
        {
            // Implémentation pour envoyer un email post-séjour au client
            throw new NotImplementedException();
        }
    }
}