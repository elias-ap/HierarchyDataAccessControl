using HierarchyDataAccessControl.Data;
using HierarchyDataAccessControl.Models;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;

namespace HierarchyDataAccessControl.Test.Integration
{
    [Collection(nameof(ContextCollectionFixture))]
    public class HierarchyDataAccessContextGetAllUsers
    {
        private readonly HierarchyDataAccessContext context;
        public HierarchyDataAccessContextGetAllUsers(ContextFixture contextFixture)
        {
            context = contextFixture.context;
        }

        [Fact]
        public void ReturnAllUsersWhenGetAllUsersFromDatabase()
        {
            // Arrange + Act
            IEnumerable<User> users = context
                .GetAllUsers();

            // Assert
            Assert.NotEmpty(users);
        }

        [Fact]
        public void ReturnAnyUserWithGroupsWhenGetAllUsersFromDatabase()
        {
            // Arrange + Act
            IEnumerable<User> users = context
                .GetAllUsers();

            // Assert
            Assert.Contains(users, u => u.Groups.Any());
        }
    }
}