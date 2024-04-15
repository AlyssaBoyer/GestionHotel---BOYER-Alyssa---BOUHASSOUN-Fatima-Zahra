using GestionHotel.Apis.Models;
using System.Collections.Generic;

namespace GestionHotel.Apis.Services
{
    public interface IChambreRepository
    {
        Chambre GetChambreById(int id);
        List<Chambre> GetChambresDisponibles(DateTime debut, DateTime fin);
        void AddChambre(Chambre chambre);
        void UpdateChambre(Chambre chambre);
        void RemoveChambre(Chambre chambre);
    }
}