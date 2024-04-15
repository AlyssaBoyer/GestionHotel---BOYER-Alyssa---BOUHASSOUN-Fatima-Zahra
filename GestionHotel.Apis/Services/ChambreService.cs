using GestionHotel.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using GestionHotel.Apis.Services.Interfaces;
using GestionHotel.Models;

namespace GestionHotel.Apis.Services
{
    public class ChambreService : IChambreService
    {
        private readonly ChambreRepository _chambreRepository;

        public ChambreService(ChambreRepository chambreRepository)
        {
            _chambreRepository = chambreRepository;
        }

        public Chambre GetChambreById(int id)
        {
            // Utiliser le repository pour obtenir la chambre par son identifiant depuis la base de données
            return _chambreRepository.GetChambreById(id);
        }

        public List<Chambre> GetChambresDisponibles(DateTime debut, DateTime fin)
        {
            // Utiliser le repository pour obtenir les chambres disponibles pour une plage de dates donnée depuis la base de données
            return _chambreRepository.GetChambresDisponibles(debut, fin);
        }
    }
}