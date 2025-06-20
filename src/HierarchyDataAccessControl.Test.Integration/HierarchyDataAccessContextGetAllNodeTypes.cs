using HierarchyDataAccessControl.Data;
using HierarchyDataAccessControl.Models;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;

namespace HierarchyDataAccessControl.Test.Integration
{
    [Collection(nameof(ContextCollectionFixture))]
    public class HierarchyDataAccessContextGetAllNodeTypes
    {
        private readonly HierarchyDataAccessContext context;
        public HierarchyDataAccessContextGetAllNodeTypes(ContextFixture contextFixture)
        {
            context = contextFixture.context;
        }

        [Fact]
        public void ReturnAllTypesWhenGetAllTypesFromDatabase()
        {
            // Arrange + Act
            IEnumerable<HierarchyNodeType> types = context.GetAllNodeTypes();

            // Assert
            Assert.NotEmpty(types);
        }
    }
}