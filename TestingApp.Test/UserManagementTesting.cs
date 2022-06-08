using System.Linq;
using TestingApp.Functionality;
using Xunit;

namespace TestingApp.Test
{
    public class UserManagementTesting
    {
        [Fact]
        public void Add_CreateUser()
        {
            // Arrange
            var userManagement = new UserManagement();

            // Act
            userManagement.Add(new("Salman", "Khan"));

            // Assert
            var savedUser = Assert.Single(userManagement.AllUsers);

            Assert.NotNull(savedUser);
            Assert.Equal("Salman", savedUser.firstName);
            Assert.Equal("Khan", savedUser.LastName);
            Assert.False(savedUser.VerifiedEmail);
        }

        [Fact]
        public void Update_UpdateMobileNumber()
        {
            // Arrange
            var userManagement = new UserManagement();

            //Act
            userManagement.Add(new("Salman", "Khan"));

            var firstUser = userManagement.AllUsers.First();
            firstUser.Phone = "9819046929";

            userManagement.UpdatePhone(firstUser);

            //Assert
            var savedUser = Assert.Single(userManagement.AllUsers);
            Assert.NotNull(savedUser);
            Assert.Equal("9819046929", savedUser.Phone);
        }
    }
}