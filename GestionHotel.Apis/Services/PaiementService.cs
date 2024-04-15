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
    }
}