using HierarchyDataAccessControl.Data;
using HierarchyDataAccessControl.Models;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;

namespace HierarchyDataAccessControl.Test.Integration
{
    [Collection(nameof(ContextCollectionFixture))]
    public class HierarchyDataAccessContextAddNode
    {
        private readonly HierarchyDataAccessContext context;
        public HierarchyDataAccessContextAddNode(ContextFixture contextFixture)
        {
            context = contextFixture.context;
        }

        [Fact]
        public void ReturnAddedNodeWhenAddNodeOnDatabase()
        {
            // Arrange
            HierarchyNode node = new HierarchyNode()
            {
                Id = Guid.NewGuid(),
                Description = "ReturnAddedNodeWhenAddNodeOnDatabase",
                TypeId = HierarchyNodeType.Company
            };

            // Act
            HierarchyNode addedNode = context.AddNode(node);

            // Assert
            Assert.NotNull(addedNode);
            Assert.Equal(node.Id, addedNode.Id);
            Assert.Equal(node.Description, addedNode.Description);
            Assert.Equal(node.TypeId, addedNode.TypeId);

            // Finally
            context.Remove(node);
            context.SaveChanges();
        }
    }
}