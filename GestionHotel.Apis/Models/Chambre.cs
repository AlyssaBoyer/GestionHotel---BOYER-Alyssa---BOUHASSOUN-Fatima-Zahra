using System;

namespace GestionHotel.Models

   public class Chambre
    {
        public int Numero { get; set; }
        public string Type { get; set; }
        public decimal Tarif { get; set; }
        public int Capacite { get; set; }
        public EtatChambre Etat { get; set; }
    }