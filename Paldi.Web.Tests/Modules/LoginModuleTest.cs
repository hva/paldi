using FakeItEasy;
using Nancy;
using Nancy.Security;
using Nancy.Testing;
using Paldi.Web.Data.Repositories;
using Paldi.Web.Modules;
using Xunit;


namespace Paldi.Web.Tests.Modules
{
    public class LoginModuleTest
    {
        private readonly Browser browser;

        public LoginModuleTest()
        {
            var usersRepo = A.Fake<IUsersRepository>();
            var bootstrapper = new ConfigurableBootstrapper(with => with
                .Module<LoginModule>()
                .ApplicationStartup((container, pipelines) =>
                {
                    Csrf.Enable(pipelines);
                })
                .Dependency(usersRepo)
            );
            browser = new Browser(bootstrapper);
        }

        [Fact]
        public void ShouldHaveValidFormElementsOnGet()
        {
            var result = browser.Get("/login");

            result.Body["form"].ShouldExistOnce().And.ShouldContainAttribute("method", "POST");
            result.Body["form input[type='text'][name='login']"].ShouldExistOnce();
            result.Body["form input[type='password'][name='password']"].ShouldExistOnce();
            result.Body["form input[type='hidden'][name='NCSRF']"].ShouldExistOnce();

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }
    }
}
