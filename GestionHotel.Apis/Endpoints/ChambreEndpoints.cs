using GestionHotel.Apis.Services.Interfaces;

namespace GestionHotel.Apis.Endpoints;

public static class ChambreEndpoints
{
    public static void MapChambreEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/v1/chambres/{id}", (int id, IChambreService chambreService) =>
        {
            Models.Chambre chambre = chambreService.GetChambreById(id);
            if (chambre == null)
                return Results.NotFound();
            return Results.Ok(chambre);
        });

        routes.MapGet("/api/v1/chambres/disponible", (int id, DateTime debut, DateTime fin, IChambreService chambreService) =>
        {
            bool disponible = chambreService.IsChambreDisponible(id, debut, fin);
            return Results.Ok(disponible);
        });
        
        routes.MapGet("/api/chambres/disponibles", (DateTime debut, DateTime fin, IChambreService chambreService) =>
        {
            var disponibles = chambreService.GetChambresDisponibles(debut, fin);
            return Results.Ok(disponibles);
        });
    }
}
