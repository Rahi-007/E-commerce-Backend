using AutoMapper;

public class CategoryService
{
    // public readonly IMapper _mapper;
    // public CategoryService(IMapper mapper)
    // {
    //     _mapper = mapper;
    // }
    private static List<Category> Categories = new List<Category>();

    public List<ResCategoryDto> GetAllCategories()
    {
        return Categories.Select(c => new ResCategoryDto
        {
            CategoryId = c.CategoryId,
            Name = c.Name,
            Narration = c.Narration,
            CreatedAt = c.CreatedAt
        }).ToList();
    }

}