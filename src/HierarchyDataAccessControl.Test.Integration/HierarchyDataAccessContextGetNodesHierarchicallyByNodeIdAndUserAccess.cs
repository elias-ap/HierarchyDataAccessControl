using HierarchyDataAccessControl.Data;
using HierarchyDataAccessControl.Models;
using Microsoft.EntityFrameworkCore;
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

        [Fact]
        public void ReturnOnlyNodesThatUserHavePermissionsWhenGetNodesHierarchicallyByNodeIdAndUserAccess()
        {
            // Arrange
            Guid hierarchyId = new Guid("a66fe7d8-354a-41fe-8638-a54a5a6cf6c6");

            //  Act
            IEnumerable<HierarchyNode> nodes = context
                .GetNodesHierarchicallyByNodeIdAndUserAccess(hierarchyId, new Guid("80c17a2a-d2ef-4c48-8d34-adb8830bfcf9"));

            // Assert
            Assert.NotEmpty(nodes);
        }
    }
}