namespace Paldi.Web.Data.Entities
{
    public class User
    {
        public string Guid { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
    }
}