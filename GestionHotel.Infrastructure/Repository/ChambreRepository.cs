
using GestionHotel.Apis.Models;
using System;
using System.Collections.Generic;

namespace GestionHotel.Apis.Services
{
    public class ChambreRepository : IChambreRepository
    {
        public IEnumerable<Chambre> GetChambresDisponibles(DateTime debut, DateTime fin)
        {
            // Implémentation pour obtenir les chambres disponibles pour une plage de dates donnée depuis la base de données
            throw new NotImplementedException();
        }

        // Autres méthodes de manipulation des chambres peuvent être implémentées ici
    }
}w