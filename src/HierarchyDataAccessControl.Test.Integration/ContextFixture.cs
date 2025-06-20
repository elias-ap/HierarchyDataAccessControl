using HierarchyDataAccessControl.Data;
using Microsoft.EntityFrameworkCore;

namespace HierarchyDataAccessControl.Test.Integration
{
    public class ContextFixture : IAsyncDisposable
    {
        public readonly HierarchyDataAccessContext context;
        public ContextFixture()
        {
            var optionBuilder = new DbContextOptionsBuilder<HierarchyDataAccessContext>();
            optionBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HierarchyDataAccessControl");
            context = new HierarchyDataAccessContext(optionBuilder.Options);
        }

        public async ValueTask DisposeAsync()
        {
            await context.DisposeAsync();
        }
    }
}