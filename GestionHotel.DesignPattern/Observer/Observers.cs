using System;
using GestionHotel.Apis.Models;

public class ClientObserver : IObserver<Reservation>
{
    public void Update(Reservation reservation)
    {
        Console.WriteLine("ClientObserver a été notifié de la mise à jour de la réservation.");
        Console.WriteLine($"La réservation pour la chambre {reservation.ChambreReservee.Id} a été mise à jour.");
    }
}

public class ReceptionnisteObserver : IObserver<Reservation>
{
    public void Update(Reservation reservation)
    {
        Console.WriteLine("ReceptionnisteObserver a été notifié de la mise à jour de la réservation.");
        Console.WriteLine($"La réservation pour la chambre {reservation.ChambreReservee.Id} a été mise à jour.");
    }
}