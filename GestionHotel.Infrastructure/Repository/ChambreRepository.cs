using GestionHotel.Apis.Models;;
using System;
using System.Collections.Generic;

namespace GestionHotel.Infrastructure.Repository
{
public class ChambreRepository : IChambreRepository
    {
        private readonly List<Chambre> _chambres;

        public ChambreRepository()
        {
            // Initialisation de la liste de chambres (simulée ici, vous devez charger les données depuis votre source de données)
            _chambres = new List<Chambre>();
        }

        public Chambre GetChambreById(int id)
        {
            // Implémentation pour obtenir une chambre par son identifiant
            return _chambres.Find(chambre => chambre.Id == id);
        }

        public List<Chambre> GetChambresDisponibles(DateTime debut, DateTime fin)
        {
            // Implémentation pour obtenir les chambres disponibles pour une plage de dates donnée
            // Vous devez implémenter la logique de recherche des chambres disponibles dans votre source de données
            throw new NotImplementedException();
        }

        public void AddChambre(Chambre chambre)
        {
            // Implémentation pour ajouter une chambre
            _chambres.Add(chambre);
        }

        public void UpdateChambre(Chambre chambre)
        {
            // Implémentation pour mettre à jour une chambre
            Chambre existingChambre = _chambres.Find(c => c.Id == chambre.Id);
            if (existingChambre != null)
            {
                // Mettre à jour les propriétés de la chambre existante
                existingChambre.Numero = chambre.Numero;
                existingChambre.Type = chambre.Type;
                existingChambre.Tarif = chambre.Tarif;
                existingChambre.Capacite = chambre.Capacite;
                existingChambre.Etat = chambre.Etat;
            }
        }

        public void RemoveChambre(Chambre chambre)
        {
            // Implémentation pour supprimer une chambre
            _chambres.Remove(chambre);
        }
    }
}
