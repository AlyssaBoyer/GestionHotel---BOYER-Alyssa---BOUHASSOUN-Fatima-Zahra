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
        // Autres dépendances injectées

        public ReservationService(ChambreRepository chambreRepository, PaiementService paiementService, ReservationRepository reservationRepository, IAuthentificationService authentificationService)
        {
            _chambreRepository = chambreRepository;
            _paiementService = paiementService;
            _reservationRepository = reservationRepository;
            _authentificationService = authentificationService;
        }
        
        public decimal CalculerMontantReservation(Chambre chambre, DateTime debut, DateTime fin)
        {
            // Calculer la durée du séjour en jours
            TimeSpan dureeSejour = fin - debut;
            int nombreJours = dureeSejour.Days;

            // Calculer le montant total en fonction du tarif journalier de la chambre
            decimal montantTotal = chambre.Tarif * nombreJours;

            return montantTotal;
        }

        public Reservation ReserverChambre(Client client, Chambre chambre, DateTime debut, DateTime fin, string numeroCarteCredit, string username, string password)
        {
            // Authentifier l'utilisateur
            bool isAuthenticated = _authentificationService.Authentifier(username, password);
            if (!isAuthenticated)
            {
                throw new UnauthorizedAccessException("L'utilisateur n'est pas authentifié.");
            }
            // Obtenir les rôles de l'utilisateur
            string[] roles = _authentificationService.ObtenirRoles(username);
            
            // Vérifier les rôles pour décider du traitement
            foreach (var role in roles)
            {
                switch (role)
                {
                    case "Client":
                        // Logique pour la réservation d'une chambre par un client
                        // Vous pouvez appeler une méthode spécifique pour la réservation par le client
                        break;
                    case "Receptionniste":
                        // Logique pour la réservation d'une chambre par un réceptionniste
                        // Vous pouvez appeler une méthode spécifique pour la réservation par le réceptionniste
                        break;
                    default:
                        throw new InvalidOperationException("Rôle utilisateur non reconnu.");
                }
            }
            
            // Vérifier si la chambre est disponible pour la plage de dates donnée
            var chambresDisponibles = _chambreRepository.GetChambresDisponibles(debut, fin);
            bool chambreDisponible = false;
            foreach (var chambreDispo in chambresDisponibles)
            {
                if (chambreDispo.Id == chambre.Id)
                {
                    chambreDisponible = true;
                    break;
                }
            }

            if (!chambreDisponible)
            {
                throw new Exception("La chambre n'est pas disponible pour les dates sélectionnées.");
            }

            // Effectuer le paiement
            bool paiementEffectue = _paiementService.ProcessPayment(numeroCarteCredit, CalculerMontantReservation(chambre, debut, fin));

            if (!paiementEffectue)
            {
                throw new Exception("Le paiement a échoué. La réservation n'a pas été effectuée.");
            }

            // Créer la réservation
            var reservation = new Reservation
            {
                Client = client,
                ChambreReservee = chambre,
                DateDebut = debut,
                DateFin = fin,
                StatutPaiement = true
            };

            // Enregistrer la réservation
            _reservationRepository.AddReservation(reservation);

            return reservation;
        }

         public void GererArrivee(Reservation reservation)
        {
            // Vérifier les autorisations du réceptionniste
            if (!_authService.IsReceptionniste())
            {
                throw new UnauthorizedAccessException("Seul le réceptionniste peut gérer l'arrivée.");
            }

            // Marquer la chambre comme occupée
            reservation.Chambre.Etat = "Occupée";

            // Gérer les paiements non effectués
            if (!reservation.PaiementEffectue)
            {
                // Si le paiement n'a pas été effectué, tentez à nouveau de traiter le paiement
                _paiementService.ProcessPayment(reservation.Client.NumeroCarteCredit, reservation.Montant);
                reservation.PaiementEffectue = true; // Marquer le paiement comme effectué
            }

            // Mettre à jour la réservation dans le repository
            _reservationRepository.UpdateReservation(reservation);
        }

        public void GererDepart(Reservation reservation)
        {
            // Vérifier les autorisations du réceptionniste
            if (!_authService.IsReceptionniste())
            {
                throw new UnauthorizedAccessException("Seul le réceptionniste peut gérer le départ.");
            }

            // Marquer la chambre pour nettoyage
            _menageService.MarquerChambrePourNettoyage(reservation.Chambre);

            // Gérer les paiements restants
            if (!reservation.PaiementEffectue)
            {
                // Si le paiement n'a pas été effectué, tentez à nouveau de traiter le paiement
                _paiementService.ProcessPayment(reservation.Client.NumeroCarteCredit, reservation.Montant);
                reservation.PaiementEffectue = true; // Marquer le paiement comme effectué
            }

            // Mettre à jour la réservation dans le repository
            _reservationRepository.UpdateReservation(reservation);
        }

        public void AnnulerReservation(Reservation reservation)
        {
            if (reservation == null || reservation.ChambreReservee.Etat == false)
            if (reservation == null || !reservation.StatutPaiement)

            {
                throw new InvalidOperationException("La réservation est déjà annulée ou n'existe pas.");
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
            else
            {
                // Pas de remboursement si l'annulation est faite moins de 24 heures avant
                // Vous pouvez enregistrer cette information ou notifier le client
            }
            reservation.StatutPaiement = false;
            reservation.EstAnnulee = true;
            // _reservationRepository.UpdateReservation(reservation);
        }
     }
}
