using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HierarchyDataAccessControl.Test.Integration
{
    [CollectionDefinition(nameof(ContextCollectionFixture))]
    public class ContextCollectionFixture : ICollectionFixture<ContextFixture> { }
}
