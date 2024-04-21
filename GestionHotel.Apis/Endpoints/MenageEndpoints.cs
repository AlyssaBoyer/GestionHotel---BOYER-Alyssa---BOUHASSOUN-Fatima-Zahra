using GestionHotel.Apis.Infrastructure.Repository.Interfaces;

namespace GestionHotel.Apis.Endpoints;

public static class MenageEndpoints
{
    public static void MapMenageEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/menage/chambres-a-nettoyer", (IPersonnelMenageRepository menageRepository) =>
        {
            var chambres = menageRepository.GetChambresANettoyer();
            return chambres.Any() ? Results.Ok(chambres) : Results.NotFound("Aucune chambre à nettoyer.");
        });
    }
}