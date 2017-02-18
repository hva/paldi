namespace Paldi.Web.Models
{
    public class LoginModel : NavigationModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public bool HasError { get; set; }
    }
}