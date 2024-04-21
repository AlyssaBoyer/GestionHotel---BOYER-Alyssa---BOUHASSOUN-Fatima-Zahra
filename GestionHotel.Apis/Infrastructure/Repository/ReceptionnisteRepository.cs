using GestionHotel.Apis.Infrastructure.Repository.Interfaces;
using GestionHotel.Apis.Models;

namespace GestionHotel.Apis.Infrastructure.Repository;

public class ReceptionnisteRepository : IReceptionnisteRepository
{
    private readonly HotelDbContext _context;

    public ReceptionnisteRepository(HotelDbContext context)
    {
        _context = context;
    }

    public Receptionniste GetReceptionnisteById(int id)
    {
        return _context.Receptionniste .FirstOrDefault(receptionniste => receptionniste.Id == id);
    }
}