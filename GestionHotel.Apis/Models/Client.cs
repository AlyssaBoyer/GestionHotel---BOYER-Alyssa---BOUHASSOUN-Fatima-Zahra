using System;
using GestionHotel.Apis.Models;
using GestionHotel.Models;

namespace GestionHotel.Apis.Models
{
    public class Client : Personne
    {
        public int Id { get; set; }
        public String NumeroCarteCredit { get; set; }
    }
}