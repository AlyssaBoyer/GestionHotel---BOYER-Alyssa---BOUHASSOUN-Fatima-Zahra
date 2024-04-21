using GestionHotel.Apis.Models;

namespace GestionHotel.Apis.Infrastructure.Repository.Interfaces;

public interface IReceptionnisteRepository
{
    Receptionniste GetReceptionnisteById(int id);
}