using GestionHotel.Apis.Models;

namespace GestionHotel.Apis.Infrastructure.Repository.Interfaces;

public interface IClientRepository
{
    Client GetClientById(int id);
}