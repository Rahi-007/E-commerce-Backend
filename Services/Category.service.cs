using AutoMapper;
using Microsoft.EntityFrameworkCore;

public class CategoryService : ICategoryService
{
    public readonly IMapper _mapper;
    private readonly AppDbContext _appDbContext;

    public CategoryService(AppDbContext appDbContext, IMapper mapper)
    {
        _mapper = mapper;
        _appDbContext = appDbContext;
    }

    public async Task<List<ResCategoryDto>> GetAllCategories()
    {
        List<Category> categories = await _appDbContext.Categories.ToListAsync();
        return _mapper.Map<List<ResCategoryDto>>(categories);
    }

    public async Task<ResCategoryDto?> GetCategoryById(Guid categoryId)
    {
        Category? category = await _appDbContext.Categories.FirstOrDefaultAsync(c => c.CategoryId == categoryId);
        return category == null ? null : _mapper.Map<ResCategoryDto>(category);
    }

    public async Task<ResCategoryDto> CreateCategory(CreateCategoryDto createData)
    {
        Category newCategory = _mapper.Map<Category>(createData);
        await _appDbContext.Categories.AddAsync(newCategory);
        await _appDbContext.SaveChangesAsync();
        return _mapper.Map<ResCategoryDto>(newCategory);
    }

    public async Task<bool> UpdateCategory(Guid categoryId, UpdateCategoryDto updateData)
    {
        var category = await _appDbContext.Categories.FirstOrDefaultAsync(c => c.CategoryId == categoryId);

        if (category == null) return false;

        category.Name = updateData.Name ?? category.Name;
        category.Narration = updateData.Narration ?? category.Narration;
        await _appDbContext.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteCategory(Guid categoryId)
    {
        var category = await _appDbContext.Categories.FirstOrDefaultAsync(c => c.CategoryId == categoryId);

        if (category == null) return false;

        _appDbContext.Categories.Remove(category);
        await _appDbContext.SaveChangesAsync();

        return true;
    }
}