using GestionHotel.Apis.Models;
using System.Collections.Generic;

namespace GestionHotel.Apis.Services
{
    public interface IChambreRepository
    {
        IEnumerable<Chambre> GetChambresDisponibles(DateTime debut, DateTime fin);
        // Autres méthodes de manipulation des chambres
    }
}