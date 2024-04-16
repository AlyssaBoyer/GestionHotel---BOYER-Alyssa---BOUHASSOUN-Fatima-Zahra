using GestionHotel.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GestionHotel.Apis.Services
{
    public class MenageService
    {
        private readonly IChambreRepository _chambreRepository;

        public MenageService(IChambreRepository chambreRepository)
        {
            _chambreRepository = chambreRepository;
        }

        public List<Chambre> GetChambresANettoyer()
        {
            // Récupérer toutes les chambres depuis le repository
            var toutesLesChambres = _chambreRepository.GetAllChambres();

            // Filtrer les chambres à nettoyer en fonction de la priorisation
            var chambresANettoyer = toutesLesChambres
                .Where(chambre => !chambre.Nettoye && !chambre.OccupeeDepuis.HasValue)
                .OrderByDescending(chambre => chambre.DerniereUtilisation);

            return chambresANettoyer.ToList();
        }

        public void MarquerChambreCommeNettoyee(Chambre chambre)
        {
            // Marquer la chambre comme nettoyée dans le repository
            chambre.Nettoye = true;
            chambre.DateNettoyage = DateTime.Now; // Ou toute autre date appropriée
            
            _chambreRepository.UpdateChambre(chambre);
        }
    }
}