namespace HierarchyDataAccessControl.Models
{
    public class AccessPermissionType
    {
        public int Id { get; set; }
        public required string Description { get; set; }

        public const int Global = 1;
        public const int Local = 2;
    }
}