public interface IUserService
{
    Task<List<UserResDto>> GetAllUsers();
    // Task<ResCategoryDto?> GetCategoryById(Guid categoryId);
    Task<UserResDto> CreateUser(CreateUserDto createData);
    // Task<bool> UpdateCategory(Guid categoryId, UpdateCategoryDto updateData);
    // Task<bool> DeleteCategory(Guid categoryId);
}