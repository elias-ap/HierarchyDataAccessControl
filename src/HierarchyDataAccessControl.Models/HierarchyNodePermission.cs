namespace HierarchyDataAccessControl.Models
{
    public class HierarchyNodePermission
    {
        public Guid Id { get; set; }
        public Guid HierarchyNodeId { get; set; }
        public string Value { get; set; }
        public List<AccessPermission> Accesess { get; set; }
    }
}
