using GestionHotel.Apis.Models;

namespace GestionHotel.Apis.Services.Interfaces
{
    public interface IPaiementService
    {
        bool ProcessPayment(string numeroCarteCredit, decimal montant);
        void ProcessRefund(Client client, decimal montantRemboursement);
    }
}
