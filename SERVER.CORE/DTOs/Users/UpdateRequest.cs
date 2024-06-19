namespace SERVER.CORE.DTOs.Users
{
    public class UpdateRequest
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int Gender { get; set; }
        public int AddressId { get; set; }
    }
}