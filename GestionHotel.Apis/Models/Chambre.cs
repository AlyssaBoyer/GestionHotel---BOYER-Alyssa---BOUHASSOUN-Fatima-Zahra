using System;

namespace GestionHotel.Models;

   public class Chambre
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public string Type { get; set; }
        public decimal Tarif { get; set; }
        public int Capacite { get; set; }
        public bool Etat { get; set; }
    }