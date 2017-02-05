namespace Paldi.Web.ViewModels
{
    public class LoginViewModel
    {
        public LoginViewModel()
        {
            Password = string.Empty;
        }

        public string Login { get; set; }
        public string Password { get; set; }
        public bool HasError { get; set; }
    }
}