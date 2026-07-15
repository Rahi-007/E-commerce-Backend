public class User : BaseEntity<Guid>
{
    public required string FirstName { get; set; }
    public string? LastName { get; set; } = string.Empty;
    public required string Phone { get; set; }
    public string? Address { get; set; } = string.Empty;
    public DateOnly? DateOfBirth { get; set; }
    public Gender Gender { get; set; }
    public Role Role { get; set; } = null!;
    public Team? Team { get; set; } = null;
    public string? RFId { get; set; } = string.Empty;
    public required string Password { get; set; }
};
