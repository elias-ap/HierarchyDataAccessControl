using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HierarchyDataAccessControl.Models
{
    public class Request
    {
        public Guid Id { get; set; }
        public required string Description { get; set; }
        public int CompanyId { get; set; }
    }
}
