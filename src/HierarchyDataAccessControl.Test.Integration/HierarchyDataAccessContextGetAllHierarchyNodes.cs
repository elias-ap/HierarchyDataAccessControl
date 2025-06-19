using HierarchyDataAccessControl.Data;
using HierarchyDataAccessControl.Models;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;

namespace HierarchyDataAccessControl.Test.Integration
{
    [Collection(nameof(ContextCollectionFixture))]
    public class HierarchyDataAccessContextGetAllHierarchyNodes
    {
        private readonly HierarchyDataAccessContext context;
        public HierarchyDataAccessContextGetAllHierarchyNodes(ContextFixture contextFixture)
        {
            context = contextFixture.context;
        }

        [Fact]
        public void ReturnAllNodesWhenGetAllNodesFromDatabase()
        {
            // Arrange + Act
            IEnumerable<HierarchyNode> nodes = context.GetAllHierarchyNodes();

            // Assert
            Assert.NotEmpty(nodes);
        }

        [Fact]
        public void ReturnAnyNodeWithChildrenNodeWhenGetAllNodesFromDatabaseIncludingTheirChildrenNodes()
        {
            // Arrange + Act
            IEnumerable<HierarchyNode> nodes = context
                .GetAllHierarchyNodes();

            // Assert
            Assert.Contains(nodes, (n) => n.ChildrenNodes.Any());
        }
    }
}