using HierarchyDataAccessControl.Data;
using HierarchyDataAccessControl.Models;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;

namespace HierarchyDataAccessControl.Test.Integration
{
    [Collection(nameof(ContextCollectionFixture))]
    public class HierarchyDataAccessContextGetEmployeesByFilter
    {
        private readonly HierarchyDataAccessContext context;
        public HierarchyDataAccessContextGetEmployeesByFilter(ContextFixture contextFixture)
        {
            context = contextFixture.context;
        }

        [Fact]
        public void ReturnExpectedEmployeesForTheUserWhenUsingHierarchyPermissions()
        {
            // Arrange
            Guid hierarchyId = Guid.Parse("5d6e2b16-11d6-4e45-9a41-eb94827f690d");
            Guid userId = Guid.Parse("1ce73cdd-eb15-4ebf-b036-48caebc44072");
            var accessValues = context
                .GetNodesHierarchicallyByNodeIdAndUserAccess(hierarchyId, userId)
                .Permissions
                .Select(e => e.Value);

            // Act
            IEnumerable<Employee> employees = context
                .GetEmployeesByFilter(f => accessValues.Contains(f.Team));

            // Assert
            Assert.NotEmpty(employees);
            Assert.All(employees, e => Assert.Contains(e.Team, accessValues));
            Assert.Collection(employees,
                e => Assert.Equal(Guid.Parse("a5d61b6b-2134-4c81-9b0c-ae9ac13251a5"), e.Id),
                e => Assert.Equal(Guid.Parse("aebbcea8-3b95-4cf7-b1c9-b4abe241077a"), e.Id)
            );
        }
    }
}