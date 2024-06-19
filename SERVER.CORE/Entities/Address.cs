using System.ComponentModel.DataAnnotations;

namespace SERVER.CORE.Entities
{
    public class Address
    {
         [Key]
        public int Id { get; set; }

        [Required]
        public string Proviance { get; set; }

        [Required]
        public string Distirct { get; set; }

        [Required]
        public string LocalGov { get; set; }

        [Required]
        public int Ward { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Tol { get; set; }
        
        // Navigation property for related Users
        public virtual ICollection<User> Users { get; set; }
    }
}