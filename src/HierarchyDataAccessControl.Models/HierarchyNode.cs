namespace HierarchyDataAccessControl.Models
{
    public class HierarchyNode
    {
        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
        public HierarchyNode Parent { get; set; }
        public string Description { get; set; }
        public List<HierarchyNode> ChildrenNodes { get; set; }
        public HierarchyNodeType Type { get; set; }
        public int TypeId { get; set; }
        public List<HierarchyNodePermission> Permissions { get; set; }
    }
}
