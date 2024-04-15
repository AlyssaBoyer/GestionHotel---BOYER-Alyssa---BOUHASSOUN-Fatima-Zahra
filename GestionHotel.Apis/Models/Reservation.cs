using System;
using GestionHotel.Models;

namespace GestionHotel.Apis.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public Client Client { get; set; }
        public Chambre ChambreReservee { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public bool StatutPaiement { get; set; }
    }
}