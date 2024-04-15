<<<<<<< HEAD
using GestionHotel.Apis.Models.Entities;
using System.Collections.Generic;

namespace GestionHotel.Infrastructure.Repository
{
    public class ChambreRepository : IChambreRepository
    {
        // Implémentation de l'accès aux données des chambres
    }
}
=======
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
}
>>>>>>> 25a5e2943d5e143efda83aa70911a352e8386239
