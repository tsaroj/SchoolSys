namespace SERVER.CORE.DTOs.Users
{
    public class UserResponse
    {
         public int Id { get; set; }
        public required string UserName { get; set; }
        public required string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public string? Phone { get; set; }
        public int Gender { get; set; }
        public int? RoleId { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Status { get; set; }
    }
}