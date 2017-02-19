namespace Paldi.Web.Models
{
    public class LoginModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public bool HasError { get; set; }
    }
}