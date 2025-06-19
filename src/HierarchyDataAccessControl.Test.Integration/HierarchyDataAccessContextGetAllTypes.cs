using HierarchyDataAccessControl.Data;
using HierarchyDataAccessControl.Models;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;

namespace HierarchyDataAccessControl.Test.Integration
{
    [Collection(nameof(ContextCollectionFixture))]
    public class HierarchyDataAccessContextGetAllTypes
    {
        private readonly HierarchyDataAccessContext context;
        public HierarchyDataAccessContextGetAllTypes(ContextFixture contextFixture)
        {
            context = contextFixture.context;
        }

        [Fact]
        public void ReturnAllTypesWhenGetAllTypesFromDatabase()
        {
            // Arrange + Act
            IEnumerable<HierarchyNodeType> types = context.GetAllTypes();

            // Assert
            Assert.NotEmpty(types);
        }
    }
}