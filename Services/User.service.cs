using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

public class UserService : IUserService
{
    public readonly IMapper _mapper;
    private readonly ICurrentUserService _currentUser;
    private readonly AppDbContext _appDbContext;
    public UserService(AppDbContext appDbContext, IMapper mapper, ICurrentUserService currentUser)
    {
        _mapper = mapper;
        _currentUser = currentUser;
        _appDbContext = appDbContext;
    }

    public async Task<List<UserResDto>> GetAllUsers()
    {
        var query = _appDbContext.Users
            .Include(u => u.Team)
            .Include(u => u.CreatedBy)
            .Include(u => u.UpdatedBy)
            .OrderByDescending(u => u.CreatedAt)
            .AsQueryable();

        var users = await query.ToListAsync();
        return _mapper.Map<List<UserResDto>>(users);
    }

    public async Task<List<SelectUserRes>> SelectUsers()
    {
        return await _appDbContext.Users
            .AsNoTracking()
            .OrderByDescending(u => u.CreatedAt)
            .ProjectTo<SelectUserRes>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<UserResDto?> GetUserById(Guid userId)
    {
        User? category = await _appDbContext.Users
            .Include(u => u.Team)
            .FirstOrDefaultAsync(u => u.Id == userId);

        return category == null ? null : _mapper.Map<UserResDto>(category);
    }

    public async Task<UserResDto> CreateUser(CreateUserDto createData)
    {
        User? existUser = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Phone == createData.Phone);
        if (existUser != null) throw new Exception("Phone number is already Exist");

        createData.Password = BCrypt.Net.BCrypt.HashPassword(createData.Password);

        User newUser = _mapper.Map<User>(createData);
        newUser.CreatedById = _currentUser.UserId;

        await _appDbContext.Users.AddAsync(newUser);
        await _appDbContext.SaveChangesAsync();
        return _mapper.Map<UserResDto>(newUser);
    }

    public async Task<bool> DeleteUser(Guid userId)
    {
        User? user = await _appDbContext.Users.FirstOrDefaultAsync(c => c.Id == userId);

        if (user == null) return false;

        _appDbContext.Users.Remove(user);
        await _appDbContext.SaveChangesAsync();

        return true;
    }
}