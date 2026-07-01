public class CreateCategoryDto
{
    public required string Name { get; set; }
    public string? Narration { get; set; } = string.Empty;
};
public class UpdateCategoryDto
{
    public string? Name { get; set; }
    public string? Narration { get; set; } = string.Empty;
};
public class ResCategoryDto
{
    public Guid CategoryId { get; set; }
    public string? Name { get; set; }
    public string? Narration { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
};