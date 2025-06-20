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
            Guid hierarchyId = new Guid("9433BB2A-8642-47B0-814A-EB5784489976");

            //  Act
            HierarchyNode node = context
                .GetNodesHierarchicallyByNodeIdAndUserAccess(hierarchyId, new Guid("80c17a2a-d2ef-4c48-8d34-adb8830bfcf9"));

            // Assert
        }
    }
}