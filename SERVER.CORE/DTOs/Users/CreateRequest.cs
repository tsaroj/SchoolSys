using System.ComponentModel.DataAnnotations;

namespace SERVER.CORE.DTOs.Users
{
   public class CreateRequest
   {
       public CreateRequest()
       {
           UserName = FirstName = LastName = Email = Password = string.Empty;
       }

       [Required]
        public  string UserName { get; set; } 

        [Required]
        public  string FirstName { get; set; }
        public string? MiddleName { get; set; }
        [Required]
        public  string LastName { get; set; }
        [Required]
        public  string Email { get; set; }
        [Required]
        public  string Password { get; set; }
        public string? Phone { get; set; }
        [Required]
        public int Gender { get; set; }
        [Required]
        public int AddressId { get; set; }
        public int RoleId { get; set; }

   }
}