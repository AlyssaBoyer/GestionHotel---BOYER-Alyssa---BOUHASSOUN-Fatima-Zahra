namespace GestionHotel.Apis.Services
{
    public class PaiementService : IPaiementService
    {
        public bool ProcessPayment(string numeroCarteCredit, decimal montant)
        {
            Console.WriteLine($"Traitement du paiement de {montant}€ avec la carte de crédit {numeroCarteCredit}...");
            Console.WriteLine("Paiement effectué avec succès.");

            return true;
        }

        public void ProcessRefund(Client client, decimal montantRemboursement)
        {
            Console.WriteLine($"Remboursement de {montantRemboursement}€ effectué pour le client {client.Nom} {client.Prenom}");
        }
    }
}