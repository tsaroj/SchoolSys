namespace SERVER.CORE.DTOs.Users
{
   public class CreateRequest
   {
        public required string UserName { get; set; }
        public required string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public string? Phone { get; set; }
        public int Gender { get; set; }
        public int AddressId { get; set; }
   }
}