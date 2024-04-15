using NUnit.Framework;
using Moq;
using System;
using NUnit.Framework.Legacy;

namespace LegacyApp
{
    [TestFixture]
    public class UserTests
    {
        [Test]
        public void AddUser_ValidUser_ReturnsTrue()
        {
            var clientId = 1;
            var firstName = "testName";
            var lastName = "Smith";
            var email = "testmail@mail.com";
    
            var userService = new UserService();

            var dateOfBirth = new DateTime(1997, 12, 1);
            bool result = userService.AddUser(firstName, lastName, email, dateOfBirth, clientId);

            ClassicAssert.IsTrue(result);
        }


        [Test]
        public void AddUser_InvalidUser_ReturnsFalse()
        {
            var mockClientRepository = new Mock<ClientRepository>();
            var mockUserCreditService = new Mock<UserCreditService>();

            var userService = new UserService(mockClientRepository.Object, mockUserCreditService.Object);
            bool result = userService.AddUser("", "", "", DateTime.Now, 1);

            ClassicAssert.IsFalse(result);
        }
    }
}