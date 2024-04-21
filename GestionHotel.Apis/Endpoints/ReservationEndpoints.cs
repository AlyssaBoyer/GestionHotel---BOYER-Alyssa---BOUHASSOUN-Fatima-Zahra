using GestionHotel.Apis.Models.InputModel;
using GestionHotel.Apis.Services.Interfaces;

namespace GestionHotel.Apis.Endpoints;

public static class ReservationEndpoints
{
    public static void MapReservationEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapPost("/api/v1/reservations", (ReservationInputModel input, IReservationService reservationService) =>
        {
            try
            {
                var reservation = reservationService.ReserverChambre(
                    input.ClientId,
                    input.ChambreId,
                    input.DateDebut,
                    input.DateFin,
                    input.NumeroCarteCredit,
                    input.Username,
                    input.Password
                );

                return Task.FromResult(Results.Ok(reservation));
            }
            catch (UnauthorizedAccessException ex)
            {
                return Task.FromResult(Results.Unauthorized());
            }
            catch (Exception ex)
            {
                return Task.FromResult(Results.Problem(detail: ex.Message));
            }
        });
    }

    public static void MapCancelReservationEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapPost("/api/v1/reservations/cancel",
            (int reservationId, string userId, IReservationService reservationService) =>
            {
                try
                {
                    var reservation = reservationService.GetReservationById(reservationId);
                    if (reservation == null)
                    {
                        return Results.NotFound("Réservation non trouvée.");
                    }

                    reservationService.AnnulerReservation(reservation, userId);
                    return Results.Ok("Réservation annulée avec succès.");
                }
                catch (UnauthorizedAccessException ex)
                {
                    return Results.Unauthorized();
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            });
    }
    
    public static void MapArrivalEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapPost("/api/v1/reservations/arrive", (int reservationId, string userId, IReservationService reservationService) =>
        {
            try
            {
                reservationService.GererArrivee(reservationId, userId);
                return Results.Ok("Arrivée gérée avec succès.");
            }
            catch (UnauthorizedAccessException ex)
            {
                return Results.Unauthorized();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        });
    }
    
    public static void MapDepartureEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapPost("/api/v1/reservations/depart", (int reservationId, string userId, IReservationService reservationService) =>
        {
            try
            {
                reservationService.GererDepart(reservationId, userId);
                return Results.Ok("Départ géré avec succès.");
            }
            catch (UnauthorizedAccessException ex)
            {
                return Results.Unauthorized();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        });
    }
    
}