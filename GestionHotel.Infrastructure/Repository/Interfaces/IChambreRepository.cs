using System;
using System.Collections.Generic;
using GestionHotel.Apis.Models;

namespace GestionHotel.Infrastructure.Repository
{
    public interface IChambreRepository
    {
        Chambre GetChambreById(int id);
        List<Chambre> GetChambresDisponibles(DateTime debut, DateTime fin);
        void AddChambre(Chambre chambre);
        void UpdateChambre(Chambre chambre);
        void RemoveChambre(Chambre chambre);
        List<ChambreEtat> GetChambresDisponiblesAvecEtat(DateTime dateDebut, DateTime dateFin);
    }
}