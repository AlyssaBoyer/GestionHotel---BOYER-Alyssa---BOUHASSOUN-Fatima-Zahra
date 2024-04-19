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
            _chambres = new List<Chambre>();
        }

        public Chambre GetChambreById(int id)
        {
            return _chambres.Find(chambre => chambre.Id == id);
        }

        public List<Chambre> GetChambresDisponibles(DateTime debut, DateTime fin)
        {
                List<Chambre> chambresDisponibles = new List<Chambre>();

                foreach (var chambre in _chambres)
                {
                    if (IsChambreDisponible(chambre, debut, fin))
                    {
                        chambresDisponibles.Add(chambre);
                    }
                }

                return chambresDisponibles;
        }

        private bool IsChambreDisponible(Chambre chambre, DateTime debut, DateTime fin)
        {
            return true;
        }

        public void AddChambre(Chambre chambre)
        {
            _chambres.Add(chambre);
        }

        public void UpdateChambre(Chambre chambre)
        {
            Chambre existingChambre = _chambres.Find(c => c.Id == chambre.Id);
            if (existingChambre != null)
            {
                existingChambre.Numero = chambre.Numero;
                existingChambre.Type = chambre.Type;
                existingChambre.Tarif = chambre.Tarif;
                existingChambre.Capacite = chambre.Capacite;
                existingChambre.Etat = chambre.Etat;
            }
        }

        public void RemoveChambre(Chambre chambre)
        {
            _chambres.Remove(chambre);
        }
        public List<ChambreEtat> GetChambresDisponiblesAvecEtat(DateTime dateDebut, DateTime dateFin)
        {
            var chambresDisponibles = new List<ChambreEtat>();
            var chambres = GetChambresDisponibles(DateTime debut, DateTime fin);
            var random = new Random();
            foreach (var chambre in chambres)
            {
                var etat = (EtatGeneralChambre)random.Next(0, Enum.GetValues(typeof(EtatGeneralChambre)).Length);
                chambresDisponibles.Add(new ChambreEtat { Chambre = chambre, EtatGeneral = etat });
            }

            return chambresDisponibles;
        }
    }
}