using Paldi.Web.Infrastructure.Services;
using Xunit;

namespace Paldi.Web.Tests.Infrastructure.Services
{
    public class PasswordServiceTest
    {
        [Theory]
        [InlineData("")]
        [InlineData("123456")]
        [InlineData("password")]
        [InlineData("12345678")]
        [InlineData("qwerty")]
        [InlineData("12345")]
        [InlineData("123456789")]
        [InlineData("football")]
        [InlineData("1234")]
        [InlineData("1234567")]
        [InlineData("baseball")]
        public void PasswordTest(string password)
        {
            var service = new PasswordService();
            var hash = service.HashPassword(password);
            Assert.True(service.VerifyPasswordHash(hash, password));

            password += "_";
            Assert.False(service.VerifyPasswordHash(hash, password));
        }
    }
}