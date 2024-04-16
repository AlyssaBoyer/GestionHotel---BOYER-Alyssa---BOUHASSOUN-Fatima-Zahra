namespace GestionHotel.Apis.Services
{
    public class PaiementService
    {
        public bool ProcessPayment(string numeroCarteCredit, decimal montant)
        {
            // Simulation du traitement du paiement
            Console.WriteLine($"Traitement du paiement de {montant}€ avec la carte de crédit {numeroCarteCredit}...");
            Console.WriteLine("Paiement effectué avec succès.");

            return true;
        }

        public void ProcessRefund(Client client, decimal montantRemboursement)
        {
            // Implémentation de la logique de remboursement
            // Par exemple, enregistrer un remboursement dans un système externe, envoyer un e-mail de confirmation, etc.
            Console.WriteLine($"Remboursement de {montantRemboursement}€ effectué pour le client {client.Nom} {client.Prenom}");
        }
    }
}