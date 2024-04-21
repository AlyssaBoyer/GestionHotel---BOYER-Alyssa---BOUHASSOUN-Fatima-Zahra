using GestionHotel.Apis;
using GestionHotel.Apis.Endpoints.Booking;
using GestionHotel.Apis.Infrastructure.Repository;
using GestionHotel.Apis.Infrastructure.Repository.Interfaces;
using GestionHotel.Apis.Services;
using GestionHotel.Apis.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<SampleInjectionInterface, SampleInjectionImplementation>();

// Enregistrez vos services et repositories ici.
builder.Services.AddScoped<IAuthentificationService, AuthentificationService>();
builder.Services.AddScoped<IChambreService, ChambreService>();
builder.Services.AddScoped<IPersonnelMenageService, PersonnelMenageService>();
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<INotificationService, NotificationService>();

// Enregistrez vos repositories si vous en avez créé.
builder.Services.AddScoped<IChambreRepository, ChambreRepository>();
builder.Services.AddScoped<IPersonnelMenageRepository, PersonnelMenageRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapBookingsEndpoints();
app.Run();
