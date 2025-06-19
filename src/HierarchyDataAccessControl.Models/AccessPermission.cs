namespace HierarchyDataAccessControl.Models
{
    public class AccessPermission
    {
        public required Guid PermissionId { get; set; }
        public required  Guid AccessId { get; set; }
    }
}
