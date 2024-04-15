using System;
using System.Collections.Generic;
using GestionHotel.Models;

namespace GestionHotel.Services
{
    public class AuthentificationService
    {
        private Dictionary<string, Client> utilisateurs;

        public AuthentificationService()
        {
            // Initialisation des utilisateurs (pour l'exemple)
            utilisateurs = new Dictionary<string, Client>
            {
                {"utilisateur1", new Client { Nom = "utilisateur1", MotPasse = "motdepasse1" }},
                {"utilisateur2", new Client { Nom = "utilisateur2", MotPasse = "motdepasse2" }},
                // Ajouter d'autres utilisateurs au besoin
            };
        }

        public bool Authentifier(Client client)
        {
            // Vérifie si le client existe dans le dictionnaire et si le mot de passe correspond
            if (utilisateurs.ContainsKey(client.Nom) && utilisateurs[client.Nom].MotPasse == client.MotPasse)
            {
                Console.WriteLine($"L'utilisateur {client.Nom} est authentifié avec succès.");
                return true;
            }
            else
            {
                Console.WriteLine($"L'authentification de l'utilisateur {client.Nom} a échoué.");
                return false;
            }
        }
    }
}