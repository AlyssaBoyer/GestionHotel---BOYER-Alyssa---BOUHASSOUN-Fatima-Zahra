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
                {"utilisateur1", new Client { NomUtilisateur = "utilisateur1", MotDePasse = "motdepasse1" }},
                {"utilisateur2", new Client { NomUtilisateur = "utilisateur2", MotDePasse = "motdepasse2" }},
                // Ajouter d'autres utilisateurs au besoin
            };
        }

        public bool Authentifier(Client client)
        {
            // Vérifie si le client existe dans le dictionnaire et si le mot de passe correspond
            if (utilisateurs.ContainsKey(client.NomUtilisateur) && utilisateurs[client.NomUtilisateur].MotDePasse == client.MotDePasse)
            {
                Console.WriteLine($"L'utilisateur {client.NomUtilisateur} est authentifié avec succès.");
                return true;
            }
            else
            {
                Console.WriteLine($"L'authentification de l'utilisateur {client.NomUtilisateur} a échoué.");
                return false;
            }
        }
    }
}