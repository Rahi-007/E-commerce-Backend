public interface ICategoryService
{
    Task<List<ResCategoryDto>> GetAllCategories();
    Task<ResCategoryDto?> GetCategoryById(Guid categoryId);
    Task<ResCategoryDto> CreateCategory(CreateCategoryDto createData);
    Task<bool> UpdateCategory(Guid categoryId, UpdateCategoryDto updateData);

    Task<bool> DeleteCategory(Guid categoryId);
}