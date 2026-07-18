using AutoMapper;
using Microsoft.EntityFrameworkCore;

public class UserService : IUserService
{
    public readonly IMapper _mapper;
    private readonly AppDbContext _appDbContext;

    public UserService(AppDbContext appDbContext, IMapper mapper)
    {
        _mapper = mapper;
        _appDbContext = appDbContext;
    }

    public async Task<List<UserResDto>> GetAllUsers()
    {
        List<User> Users = await _appDbContext.Users.ToListAsync();
        return _mapper.Map<List<UserResDto>>(Users);
    }

    public async Task<UserResDto> CreateUser(CreateUserDto createData)
    {
        User newUser = _mapper.Map<User>(createData);
        await _appDbContext.Users.AddAsync(newUser);
        await _appDbContext.SaveChangesAsync();
        return _mapper.Map<UserResDto>(newUser);
    }
}