namespace GestionHotel.Apis.Models.InputModel;

public class ReservationInputModel
{
    public int ClientId { get; set; }
    public int ChambreId { get; set; }
    public DateTime DateDebut { get; set; }
    public DateTime DateFin { get; set; }
    public string NumeroCarteCredit { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}