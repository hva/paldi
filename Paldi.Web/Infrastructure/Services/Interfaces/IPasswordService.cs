namespace Paldi.Web.Infrastructure.Services.Interfaces
{
    public interface IPasswordService
    {
        string HashPassword(string password);
        bool VerifyPasswordHash(string savedPasswordHash, string password);
    }
}