using HierarchyDataAccessControl.Data;
using HierarchyDataAccessControl.Models;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;

namespace HierarchyDataAccessControl.Test.Integration
{
    [Collection(nameof(ContextCollectionFixture))]
    public class HierarchyDataAccessContextGetAllNodesHierarchically
    {
        private readonly HierarchyDataAccessContext context;
        public HierarchyDataAccessContextGetAllNodesHierarchically(ContextFixture contextFixture)
        {
            context = contextFixture.context;
        }

        [Fact]
        public async Task ReturnNodeHierarchicallyOrganizedWhenGetAllNodesHierarchicallyAsync()
        {
            // Arrange + Act
            IEnumerable<HierarchyNode> nodes = await context
                .GetAllNodesHierarchicallyAsync();

            // Assert
            Assert.NotEmpty(nodes);
        }

        [Fact]
        public void ReturnNodeHierarchicallyOrganizedWhenGetAllNodesHierarchically()
        {
            // Arrange + Act
            IEnumerable<HierarchyNode> nodes = context
                .GetAllNodesHierarchically();

            // Assert
            Assert.NotEmpty(nodes);
        }
    }
}