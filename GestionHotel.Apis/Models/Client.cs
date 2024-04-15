using System;

namespace GestionHotel.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Email { get; set; }
        public string MotPasse { get; set; }
    }
}