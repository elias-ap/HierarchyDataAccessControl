namespace HierarchyDataAccessControl.Models
{
    public class HierarchyNodeType
    {
        public int Id { get; set; }
        public required string Description { get; set; }

        public const int Company = 1;
        public const int Department = 2;
        public const int Team = 3;
    }
}
