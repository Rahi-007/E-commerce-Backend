public interface IUserService
{
    Task<List<UserResDto>> GetAllUsers();
    Task<List<SelectUserRes>> SelectUsers();
    Task<UserResDto?> GetUserById(Guid userId);
    Task<UserResDto> CreateUser(CreateUserDto createData);
    // Task<bool> UpdateCategory(Guid categoryId, UpdateCategoryDto updateData);
    Task<bool> DeleteUser(Guid userId);
}