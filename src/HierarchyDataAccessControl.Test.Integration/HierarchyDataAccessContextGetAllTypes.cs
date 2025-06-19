using HierarchyDataAccessControl.Data;
using HierarchyDataAccessControl.Models;
using Microsoft.EntityFrameworkCore;

namespace HierarchyDataAccessControl.Test.Integration
{
    public class HierarchyDataAccessContextGetAllTypes
    {
        [Fact]
        public void ReturnAllTypesWhenGetAllTypesFromDatabase()
        {
            // Arrange
            var optionBuilder = new DbContextOptionsBuilder<HierarchyDataAccessContext>();
            optionBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HierarchyDataAccessControl");
            var context = new HierarchyDataAccessContext(optionBuilder.Options);

            // Act
            IEnumerable<HierarchyNodeType> types = context.GetAllTypes();

            // Assert
            Assert.NotEmpty(types);
        }
    }
}