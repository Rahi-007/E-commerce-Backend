using AutoMapper;
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

    public async Task<List<UserResDto>> GetAllUsers(string? search)
    {
        var query = _appDbContext.Users
            .Include(u => u.Team)
            .Include(u => u.CreatedBy)
            .Include(u => u.UpdatedBy)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            search = search.Trim().ToLower();
            query = query.Where(u =>
                EF.Functions.ILike(u.FirstName, $"%{search}%") ||
                EF.Functions.ILike(u.LastName!, $"%{search}%") ||
                EF.Functions.ILike(u.Phone, $"%{search}%"));
        }

        var users = await query.ToListAsync();

        return _mapper.Map<List<UserResDto>>(users);
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
        // await _appDbContext.Entry(newUser)
        //     .Reference(x => x.CreatedBy)
        //     .LoadAsync();
        return _mapper.Map<UserResDto>(newUser);
    }
}