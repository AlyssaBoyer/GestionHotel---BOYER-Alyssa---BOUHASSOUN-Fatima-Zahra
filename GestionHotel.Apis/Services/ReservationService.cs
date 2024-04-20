using GestionHotel.Apis.Models;
using GestionHotel.Apis.Services.Interfaces;
using GestionHotel.Infrastructure.Repository;
using GestionHotel.Models;

namespace GestionHotel.Apis.Services
{
    public class ReservationService 
    {
        private readonly ChambreRepository _chambreRepository;
        private readonly PaiementService _paiementService;
        private readonly ReservationRepository _reservationRepository;
        private readonly NotificationService _notificationService;
        private readonly AuthentificationService _authentificationService

        public ReservationService(ChambreRepository chambreRepository, PaiementService paiementService, ReservationRepository reservationRepository,NotificationService notificationService, IAuthentificationService authentificationService)
        {
            _chambreRepository = chambreRepository;
            _paiementService = paiementService;
            _reservationRepository = reservationRepository;
            _notificationService = notificationService;
            _authentificationService = authentificationService;
        }
        
        public decimal CalculerMontantReservation(Chambre chambre, DateTime debut, DateTime fin)
        {
            TimeSpan dureeSejour = fin - debut;
            int nombreJours = dureeSejour.Days;

            decimal montantTotal = chambre.Tarif * nombreJours;

            return montantTotal;
        }

        public Reservation ReserverChambre(Client client, Chambre chambre, DateTime debut, DateTime fin, string numeroCarteCredit, string username, string password)
        {
            if (!_authentificationService.Authentifier(username, password))
            {
                throw new UnauthorizedAccessException("L'utilisateur n'est pas authentifié.");
            }
            if (!_chambreRepository.IsChambreDisponible(chambre.Id, debut, fin))
            {
                throw new Exception("La chambre n'est pas disponible pour les dates sélectionnées.");
            }
            decimal montantTotal = CalculerMontantReservation(chambre, debut, fin);
            if (!_paiementService.ProcessPayment(numeroCarteCredit, montantTotal))
            {
                throw new Exception("Le paiement a échoué. La réservation n'a pas été effectuée.");
            }

            var reservation = new Reservation
            {
                Client = client,
                ChambreReservee = chambre,
                DateDebut = debut,
                DateFin = fin,
                StatutPaiement = true
            };

            _reservationRepository.AddReservation(reservation);

            return reservation;
        }


         public void GererArrivee(Reservation reservation)
        {
                if (!_authentificationService.IsReceptionniste())
            {
                 throw new UnauthorizedAccessException("Seul le réceptionniste peut gérer une arrivée.");
            }
            reservation.Chambre.Etat = "Occupée";
            if (!reservation.PaiementEffectue)
            {
                _paiementService.ProcessPayment(reservation.Client.NumeroCarteCredit, reservation.Montant);
                reservation.PaiementEffectue = true;
            }
            _reservationRepository.UpdateReservation(reservation);
        }

        public void GererDepart(Reservation reservation)
        {
            if (!_authService.IsReceptionniste())
            {
                throw new UnauthorizedAccessException("Seul le réceptionniste peut gérer le départ.");
            }
            _menageService.MarquerChambrePourNettoyage(reservation.Chambre);
            if (!reservation.PaiementEffectue)
            {
                _paiementService.ProcessPayment(reservation.Client.NumeroCarteCredit, reservation.Montant);
                reservation.PaiementEffectue = true; 
            }

            _reservationRepository.UpdateReservation(reservation);
        }

        public void AnnulerReservation(Reservation reservation)
        {
            if (reservation == null || reservation.ChambreReservee.Etat == false)
            if (reservation == null || !reservation.StatutPaiement)

            {
                throw new InvalidOperationException("La réservation est déjà annulée ou n'existe pas.");
            }

                if (!_authentificationService.IsReceptionniste())
            {
                 throw new UnauthorizedAccessException("Seul le réceptionniste peut annuler une réservation.");
            }
            reservation.ChambreReservee.Etat = false;
            TimeSpan differenceJours = reservation.DateDebut - DateTime.Now;
            if (differenceJours.TotalDays > 7)
            {
                 _paiementService.ProcessRefund(reservation.Client, reservation.Montant);
            }
            else if (differenceJours.TotalDays > 1)
            {
                 _paiementService.ProcessRefund(reservation.Client, reservation.Montant * 0.5);
            }
            else if (differenceJours.TotalHours < 24)
            {
                _notificationService.NotifierAnnulationTardive(reservation.Client);
            }
            reservation.StatutPaiement = false;
            reservation.EstAnnulee = true;
             _reservationRepository.UpdateReservation(reservation);
        }
     }
}
