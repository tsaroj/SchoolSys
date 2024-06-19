using System.ComponentModel.DataAnnotations;

namespace SERVER.CORE.Entities
{
    public class Role
    {
         [Key]
        public int Id { get; set; }

        [Required]
        public required string RoleName { get; set; }

        [Required]
        public string? GuardName { get; set; }

        [Required]
        public bool Status { get; set; }

        [Required]
        public int PermissionId { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

        public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
  
    }
}