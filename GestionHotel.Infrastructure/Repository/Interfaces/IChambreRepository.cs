using GestionHotel.Apis.Models;
using System.Collections.Generic;

namespace GestionHotel.Apis.Services
{
    public interface IChambreRepository
    {
        Chambre GetChambreById(int id);
        List<Chambre> GetChambresDisponibles(DateTime debut, DateTime fin);
        List<ChambreEtat> GetChambresDisponiblesAvecEtat(DateTime dateDebut, DateTime dateFin);
        void AddChambre(Chambre chambre);
        void UpdateChambre(Chambre chambre);
        void RemoveChambre(Chambre chambre);
    }
    
}