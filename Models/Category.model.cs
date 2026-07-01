public class Category
{
    public Guid CategoryId { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }
    public string Narration { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
};