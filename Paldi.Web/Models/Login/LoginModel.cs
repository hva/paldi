namespace Paldi.Web.Models.Login
{
    public class LoginModel : IModel
    {
        public string Login { get; set; }
        public bool HasError { get; set; }
    }
}