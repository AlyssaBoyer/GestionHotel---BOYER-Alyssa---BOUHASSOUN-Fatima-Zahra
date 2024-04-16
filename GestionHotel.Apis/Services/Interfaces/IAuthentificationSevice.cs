namespace GestionHotel.Apis.Services
{
    public interface IAuthentificationService
    {
        bool AuthentifierClient(string username, string password);
        bool AuthentifierReceptionniste(string username, string password);
        string[] ObtenirRoles(string username);
    }
}