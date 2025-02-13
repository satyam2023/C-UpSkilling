
namespace WebApis.Services.UserServices;
using AutoMapper;
using WebApis.Helpers;
using WebApis.Models.Dtos;
using WebApis.Models.Entities;
using BCrypt.Net;

public interface IUserService
{
    UserResponse createUser(CreateUser userData);
    UserResponse? signIn(SignInUserRequest userRequest);

    void updateUser(UpdateUserRequest userData);
}

public class UserServices : IUserService
{
    private DataContext _context;
    private readonly IMapper _mapper;

    public UserServices(
        DataContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public UserResponse createUser(CreateUser userData)
    {
        if (_context.Users.Any(u => u.email == userData.email))
        {
            throw new Exception("User with the email '" + userData.email + "' already exists");
        }
        var user = _mapper.Map<User>(userData);
        user.passwordHash = BCrypt.HashPassword(userData.password);
        _context.Users.Add(user);
        _context.SaveChanges();
        var userResponse = _mapper.Map<UserResponse>(user);
        return userResponse;
    }

    public UserResponse? signIn(SignInUserRequest userRequest)
    {
        var user = _context.Users.FirstOrDefault(u => u.email == userRequest.email);
        if (user == null || !BCrypt.Verify(userRequest.password, user.passwordHash))
            return null;

        var userData = _mapper.Map<UserResponse>(user);

        return userData;

    }

    public void updateUser(UpdateUserRequest userData)
    {

        var targetUser = _context.Users.Find(userData.Id);


        if (targetUser == null)
        {
            throw new KeyNotFoundException($"User with Id {userData.Id} not found.");
        }

        targetUser.email = userData.email ?? targetUser.email;
        targetUser.age = userData.age ?? targetUser.age;

        _context.SaveChanges();
    }


}
