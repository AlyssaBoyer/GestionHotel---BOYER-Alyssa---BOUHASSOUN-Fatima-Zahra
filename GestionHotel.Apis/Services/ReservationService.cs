using GestionHotel.Apis.Infrastructure.Repository;
using GestionHotel.Apis.Infrastructure.Repository.Interfaces;
using GestionHotel.Apis.Models;
using GestionHotel.Apis.Services.Interfaces;
using GestionHotel.Models;

namespace GestionHotel.Apis.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IChambreRepository _chambreRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IReceptionnisteRepository _receptionnisteRepository;
        private readonly IPaiementService _paiementService;
        private readonly IReservationRepository _reservationRepository;
        private readonly INotificationService _notificationService;
        private readonly IAuthentificationService _authentificationService;
        private readonly IPersonnelMenageService _menageService;
        private readonly List<IObserver<Reservation>> _reservationObservers = new List<IObserver<Reservation>>();


        public ReservationService(IChambreRepository chambreRepository, IPaiementService paiementService,
            IReservationRepository reservationRepository, INotificationService notificationService,
            IAuthentificationService authentificationService, IPersonnelMenageService menageService,
            IClientRepository clientRepository, IReceptionnisteRepository receptionnisteRepository)
        {
            _chambreRepository = chambreRepository;
            _paiementService = paiementService;
            _reservationRepository = reservationRepository;
            _notificationService = notificationService;
            _authentificationService = authentificationService;
            _menageService = menageService;
            _clientRepository = clientRepository;
            _receptionnisteRepository = receptionnisteRepository;
        }

        public Reservation ReserverChambre(int clientId, int chambreId, DateTime debut, DateTime fin,
            string numeroCarteCredit, string username, string password)
        {
            if (!_authentificationService.AuthentifierClient(username, password))
            {
                throw new UnauthorizedAccessException("L'utilisateur n'est pas authentifié.");
            }

            if (!_chambreRepository.IsChambreDisponible(clientId, debut, fin))
            {
                throw new Exception("La chambre n'est pas disponible pour les dates sélectionnées.");
            }

            decimal montantTotal = CalculerMontantReservation(chambreId, debut, fin);
            if (!_paiementService.ProcessPayment(numeroCarteCredit, montantTotal))
            {
                throw new Exception("Le paiement a échoué. La réservation n'a pas été effectuée.");
            }

            var reservation = new Reservation
            {
                ClientId = clientId,
                ChambreReserveeId = chambreId,
                DateDebut = debut,
                DateFin = fin,
                StatutPaiement = true,
                Montant = montantTotal
            };

            _reservationRepository.AddReservation(reservation);
            NotifyReservationObservers(reservation);

            return reservation;
        }

        public void AnnulerReservation(Reservation reservation, string userId)
        {
            Chambre chambre = _chambreRepository.GetChambreById(reservation.ChambreReserveeId);
            Client client = _clientRepository.GetClientById(reservation.ClientId);

            if (chambre.Etat == false)
                if (reservation == null || !reservation.StatutPaiement)

                {
                    throw new InvalidOperationException("La réservation est déjà annulée ou n'existe pas.");
                }

            if (!_authentificationService.IsReceptionniste(userId))
            {
                throw new UnauthorizedAccessException("Seul le réceptionniste peut annuler une réservation.");
            }

            chambre.Etat = false;
            TimeSpan differenceJours = reservation.DateDebut - DateTime.Now;
            if (differenceJours.TotalDays > 7)
            {
                _paiementService.ProcessRefund(client, reservation.Montant);
            }
            else if (differenceJours.TotalDays > 1)
            {
                _paiementService.ProcessRefund(client, reservation.Montant * 0.5m);
            }
            else if (differenceJours.TotalHours < 24)
            {
                _notificationService.NotifierAnnulationTardive(client);
            }

            reservation.StatutPaiement = false;
            reservation.EstAnnulee = true;
            _reservationRepository.UpdateReservation(reservation);

            // Notifier les observateurs de l'annulation de la réservation
            NotifyReservationObservers(reservation);
        }

        // Méthode pour notifier les observateurs lorsqu'un événement pertinent se produit
        private void NotifyReservationObservers(Reservation reservation)
        {
            foreach (var observer in _reservationObservers)
            {
                observer.OnNext(reservation);
            }
        }

        private decimal CalculerMontantReservation(int chambreId, DateTime debut, DateTime fin)
        {
            Chambre chambre = _chambreRepository.GetChambreById(chambreId);

            TimeSpan dureeSejour = fin - debut;
            int nombreJours = dureeSejour.Days;

            decimal montantTotal = chambre.Tarif * nombreJours;

            return montantTotal;
        }

        public void GererArrivee(Reservation reservation, string userId)
        {
            if (!_authentificationService.IsReceptionniste(userId))
            {
                throw new UnauthorizedAccessException("Seul le réceptionniste peut gérer une arrivée.");
            }

            Chambre chambre = _chambreRepository.GetChambreById(reservation.ChambreReserveeId);
            chambre.Etat = true;

            if (!reservation.StatutPaiement)
            {
                Client client = _clientRepository.GetClientById(reservation.ClientId);
                _paiementService.ProcessPayment(client.NumeroCarteCredit, reservation.Montant);
                reservation.StatutPaiement = true;
            }

            _reservationRepository.UpdateReservation(reservation);
            NotifyReservationObservers(reservation);
        }

        public void GererDepart(Reservation reservation, string userId)
        {
            if (!_authentificationService.IsReceptionniste(userId))
            {
                throw new UnauthorizedAccessException("Seul le réceptionniste peut gérer le départ.");
            }

            Chambre chambre = _chambreRepository.GetChambreById(reservation.ChambreReserveeId);

            _menageService.MarquerChambrePourNettoyage(chambre.Id);
            if (!reservation.StatutPaiement)
            {
                Client client = _clientRepository.GetClientById(reservation.ClientId);
                _paiementService.ProcessPayment(client.NumeroCarteCredit, reservation.Montant);
                reservation.StatutPaiement = true;
            }

            _reservationRepository.UpdateReservation(reservation);
            NotifyReservationObservers(reservation);
        }

        public Reservation GetReservationById(int id)
        {
            return _reservationRepository.GetReservationById(id);
        }
    }
}