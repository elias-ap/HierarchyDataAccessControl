namespace HierarchyDataAccessControl.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<AccessGroup> Groups { get; set; }
    }
}
