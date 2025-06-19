using HierarchyDataAccessControl.Data;
using HierarchyDataAccessControl.Models;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;

namespace HierarchyDataAccessControl.Test.Integration
{
    [Collection(nameof(ContextCollectionFixture))]
    public class HierarchyDataAccessContextGetAllFirstLevelHierarchyNodes
    {
        private readonly HierarchyDataAccessContext context;
        public HierarchyDataAccessContextGetAllFirstLevelHierarchyNodes(ContextFixture contextFixture)
        {
            context = contextFixture.context;
        }

        [Fact]
        public void ReturnAllFirstLevelNodesWhenGetAllFirstLevelHierarchyNodes()
        {
            // Arrange
            var allCurrentlyNodes = context
                .GetAllHierarchyNodes()
                .Where(hn => hn.TypeId == 1);

            // Act
            IEnumerable<HierarchyNode> firstLevelNodes = context
                .GetAllFirstLevelHierarchyNodes();

            // Assert
            Assert.Equal(allCurrentlyNodes.Count(), firstLevelNodes.Count());
        }
    }
}