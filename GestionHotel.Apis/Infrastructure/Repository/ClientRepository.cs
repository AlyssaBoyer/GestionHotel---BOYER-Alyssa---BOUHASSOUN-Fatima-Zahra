using GestionHotel.Apis.Infrastructure.Repository.Interfaces;
using GestionHotel.Apis.Models;

namespace GestionHotel.Apis.Infrastructure.Repository;

public class ClientRepository : IClientRepository
{
    private readonly HotelDbContext _context;

    public ClientRepository(HotelDbContext context)
    {
        _context = context;
    }

    public Client GetClientById(int id)
    {
        return _context.Client .FirstOrDefault(client => client.Id == id);
    }
}