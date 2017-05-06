namespace Paldi.Web.Services.Password
{
    public interface IPasswordService
    {
        string HashPassword(string password);
        bool VerifyPasswordHash(string savedPasswordHash, string password);
    }
}