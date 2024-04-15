using GestionHotel.Apis.Models;
using GestionHotel.Models;

namespace GestionHotel.Infrastructure.Repository
{
    public class ChambreRepository 
    {
        private readonly List<Chambre> _chambres; // Supposons que _chambres est votre source de données

        public ChambreRepository()
        {
            // Initialisation de la liste des chambres (c'est un exemple, vous devez charger les données depuis votre source de données)
            _chambres = new List<Chambre>
            {
                new Chambre { Id = 1, Numero = 101, Type = "Simple", Tarif = 100, Capacite = 1, Etat = true },
                new Chambre { Id = 2, Numero = 102, Type = "Double", Tarif = 150, Capacite = 2, Etat = false },
                // Ajoutez d'autres chambres ici...
            };
        }

        public Chambre GetChambreById(int id)
        {
            // Recherche de la chambre correspondant à l'ID spécifié
            return _chambres.Find(chambre => chambre.Id == id);
        }
        
        public List<Chambre> GetChambresDisponibles(DateTime debut, DateTime fin)
        {
            // Implémentation pour obtenir les chambres disponibles pour une plage de dates donnée
            // Vous devez adapter cette logique en fonction de votre source de données réelle
            List<Chambre> chambresDisponibles = new List<Chambre>();

            foreach (Chambre chambre in _chambres)
            {
                // Vérifier si la chambre est disponible pour la plage de dates spécifiée
                // Vous devez implémenter votre propre logique de disponibilité des chambres ici
                // Par exemple, vérifier les réservations existantes pour cette chambre et voir si elle est disponible pour la plage de dates spécifiée

                bool chambreDisponible = true; // Implémentez votre propre logique de disponibilité ici

                if (chambreDisponible)
                {
                    chambresDisponibles.Add(chambre);
                }
            }

            return chambresDisponibles;
        }
    }
}
