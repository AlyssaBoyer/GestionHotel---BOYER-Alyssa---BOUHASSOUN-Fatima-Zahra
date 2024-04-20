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
                        return _chambreRepository.GetChambreById(id);
        }

        public List<Chambre> GetChambresDisponibles(DateTime debut, DateTime fin)
        {
            return _chambreRepository.GetChambresDisponibles(debut, fin);
        }
    }
}