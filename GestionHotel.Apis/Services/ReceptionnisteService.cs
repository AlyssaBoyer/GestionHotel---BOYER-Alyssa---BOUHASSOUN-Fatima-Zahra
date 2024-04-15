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
        public Reservation ReserverChambreAvecEtat(Chambre chambre, DateTime debut, DateTime fin, string numeroCarteCredit, string etatChambre)
        {
            // Récupérer la chambre sélectionnée avec son état
            chambre.Etat = etatChambre;

            // Créer une nouvelle réservation
            Reservation reservation = new Reservation
            {
                Chambre = chambre,
                DateDebut = debut,
                DateFin = fin
            };

            // Effectuer le paiement
            bool paiementEffectue = _paiementService.ProcessPayment(numeroCarteCredit, CalculerMontantReservation(chambre, debut, fin));

            // Si le paiement est réussi, enregistrer la réservation
            if (paiementEffectue)
            {
                _reservationRepository.AddReservation(reservation);
                return reservation;
            }
            else
            {
                // Gérer l'échec du paiement
                throw new Exception("Le paiement a échoué. La réservation n'a pas été effectuée.");
            }
        }
        public IEnumerable<Chambre> GetChambresDisponiblesAvecEtat(DateTime debut, DateTime fin)
        {
            // Récupérer les chambres disponibles avec leur état
            var chambresDisponibles = _chambreRepository.GetChambresDisponibles(debut, fin);
            foreach (var chambre in chambresDisponibles)
            {
                // Ajouter des informations sur l'état de la chambre
                chambre.Etat = GetEtatChambre(chambre);
            }
            return chambresDisponibles;
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