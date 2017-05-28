namespace Paldi.Web.Services
{
    public interface IPasswordService
    {
        string HashPassword(string password);
        bool VerifyPasswordHash(string savedPasswordHash, string password);
    }
}