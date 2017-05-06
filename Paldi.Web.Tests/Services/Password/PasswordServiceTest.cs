using Paldi.Web.Services.Password;
using Xunit;

namespace Paldi.Web.Tests.Services.Password
{
    public class PasswordServiceTest
    {
        [Fact]
        public void PasswordTest()
        {
            var service = new PasswordService();

            var passwords = new[]
            {
                "",
                "123456",
                "password",
                "12345678",
                "qwerty",
                "12345",
                "123456789",
                "football",
                "1234",
                "1234567",
                "baseball"
            };

            foreach (var password in passwords)
            {
                var hash = service.HashPassword(password);
                Assert.True(service.VerifyPasswordHash(hash, password));
                Assert.False(service.VerifyPasswordHash(hash, password + "_"));
            }
        }
    }
}