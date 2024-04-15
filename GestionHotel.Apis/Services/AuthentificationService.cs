using System;
using System.Collections.Generic;

namespace GestionHotel.Services
{
    public class AuthentificationService
    {
        private Dictionary<string, string> utilisateurs;

        public AuthentificationService()
        {
            utilisateurs = new Dictionary<string, string>
            {
                {"utilisateur1", "motdepasse1"},
                {"utilisateur2", "motdepasse2"},
            };
        }

        public bool Authentifier(string nomUtilisateur, string motDePasse)
        {
            if (utilisateurs.ContainsKey(nomUtilisateur) && utilisateurs[nomUtilisateur] == motDePasse)
            {
                Console.WriteLine($"L'utilisateur {nomUtilisateur} est authentifié avec succès.");
                return true;
            }
            else
            {
                Console.WriteLine($"L'authentification de l'utilisateur {nomUtilisateur} a échoué.");
                return false;
            }
        }
    }
}
