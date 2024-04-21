using System;
using GestionHotel.Models;

namespace GestionHotel.Apis.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int ChambreReserveeId { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public bool StatutPaiement { get; set; }
        public bool EstAnnulee { get; set; }
        public Decimal Montant { get; set; }
    }
}