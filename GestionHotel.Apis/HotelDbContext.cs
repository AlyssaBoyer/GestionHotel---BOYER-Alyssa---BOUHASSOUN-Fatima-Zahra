using GestionHotel.Apis.Models;
using Microsoft.EntityFrameworkCore;
using GestionHotel.Models;

namespace GestionHotel.Apis;


public class HotelDbContext : DbContext
{
    public DbSet<Chambre> Chambres { get; set; }
    public DbSet<Client> Client { get; set; }
    public DbSet<Personne> Personne { get; set; }
    public DbSet<PersonnelMenage> PersonnelMenage { get; set; }
    public DbSet<Receptionniste> Receptionniste { get; set; }
    public DbSet<Reservation> Reservations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=hotel.db");
    }
    public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
    {
    }
}
