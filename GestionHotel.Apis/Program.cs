using GestionHotel.Apis;
using GestionHotel.Apis.Endpoints;
using GestionHotel.Apis.Infrastructure.Repository;
using GestionHotel.Apis.Infrastructure.Repository.Interfaces;
using GestionHotel.Apis.Services;
using GestionHotel.Apis.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Enregistrez vos services et repositories ici.
builder.Services.AddScoped<IAuthentificationService, AuthentificationService>();
builder.Services.AddScoped<IChambreService, ChambreService>();
builder.Services.AddScoped<IPersonnelMenageService, PersonnelMenageService>();
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IPaiementService, PaiementService>();

// Enregistrez vos repositories si vous en avez créé.
builder.Services.AddScoped<IChambreRepository, ChambreRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IReceptionnisteRepository, ReceptionnisteRepository>();
builder.Services.AddScoped<IPersonnelMenageRepository, PersonnelMenageRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();

builder.Services.AddDbContext<HotelDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("HotelDatabase")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapChambreEndpoints();
app.MapReservationEndpoints();
app.MapCancelReservationEndpoints();
app.MapArrivalEndpoints();
app.MapDepartureEndpoints();
app.MapMenageEndpoints();

app.Run();
