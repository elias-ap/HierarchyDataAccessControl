using HierarchyDataAccessControl.Data;
using HierarchyDataAccessControl.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.Hierarchy;
using System.Dynamic;

namespace HierarchyDataAccessControl.Test.Integration
{
    [Collection(nameof(ContextCollectionFixture))]
    public class HierarchyDataAccessContextGetNodesHierarchicallyByNodeIdAndUserAccess
    {
        private readonly HierarchyDataAccessContext context;
        public HierarchyDataAccessContextGetNodesHierarchicallyByNodeIdAndUserAccess(ContextFixture contextFixture)
        {
            context = contextFixture.context;
        }

        [Theory]
        [InlineData("9433BB2A-8642-47B0-814A-EB5784489976", "80c17a2a-d2ef-4c48-8d34-adb8830bfcf9")]
        [InlineData("5d6e2b16-11d6-4e45-9a41-eb94827f690d", "1ce73cdd-eb15-4ebf-b036-48caebc44072")]
        [InlineData("5d6e2b16-11d6-4e45-9a41-eb94827f690d", "80c17a2a-d2ef-4c48-8d34-adb8830bfcf9")]
        public void ReturnOnlyNodesThatUserHavePermissionsWhenGetNodesHierarchicallyByNodeIdAndUserAccess(
            string hierarchyIdString,
            string userIdString
            )
        {
            // Arrange
            Guid hierarchyId = new Guid(hierarchyIdString);
            Guid userId = new Guid(userIdString);

            //  Act
            HierarchyNode node = context
                .GetNodesHierarchicallyByNodeIdAndUserAccess(hierarchyId, userId);

            // Assert
            Assert.NotNull(node);
            Assert.NotEmpty(node.Permissions);
        }
    }
}