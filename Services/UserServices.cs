
namespace WebApis.Services.UserServices;
using AutoMapper;
using WebApis.Helpers;
using WebApis.Models.Dtos;
using WebApis.Models.Entities;
using BCrypt.Net;
using WebApis.Helpers.AuthCore;
using WebApis.Constant.StringConstant;

public interface IUserService
{
    UserAuthResponse createUser(CreateUser userData);
    UserAuthResponse? signIn(SignInUserRequest userRequest);
    void updateUser(UpdateUserRequest userData);
    UserAuthResponse refreshToken(RefreshTokenRequest token);
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
    public UserAuthResponse createUser(CreateUser userData)
    {
        if (_context.Users.Any(u => u.email == userData.email))
        {
            throw new Exception("User with the email '" + userData.email + "' already exists");
        }
        var user = _mapper.Map<User>(userData);
        user.passwordHash = BCrypt.HashPassword(userData.password);
        var refreshToken = AuthCore.GenerateRefreshToken();
        user.refreshToken = refreshToken;
        _context.Users.Add(user);
        _context.SaveChanges();
        var accessToken = AuthCore.GenerateAccessToken(user);
        var userResponse = new UserAuthResponse
        {
            accessToken = accessToken,
            refreshToken = refreshToken
        };
        return userResponse;
    }

    public UserAuthResponse? signIn(SignInUserRequest userRequest)
    {
        var user = _context.Users.FirstOrDefault(u => u.email == userRequest.email);
        if (user == null || !BCrypt.Verify(userRequest.password, user.passwordHash))
            return null;
        var refreshToken = AuthCore.GenerateRefreshToken();
        var accessToken = AuthCore.GenerateAccessToken(user);
        user.refreshToken = refreshToken;
        _context.SaveChanges();
        var userResponse = new UserAuthResponse
        {
            accessToken = accessToken,
            refreshToken = refreshToken
        };
        return userResponse;
    }

    public void updateUser(UpdateUserRequest userData)
    {
        var targetUser = _context.Users.Find(userData.Id);
        targetUser.email = userData.email ?? targetUser.email;
        targetUser.age = userData.age ?? targetUser.age;
        _context.SaveChanges();
    }

    public UserAuthResponse refreshToken(RefreshTokenRequest token)
    {

        var user = _context.Users.FirstOrDefault(u => u.refreshToken == token.refreshToken);
        if (user == null){
            throw new Exception(StringConstant.userTokenNotExist + token.refreshToken );
        }
        var accessToken = AuthCore.GenerateAccessToken(user);
        var userResponse = new UserAuthResponse
        {
            accessToken = accessToken
        };
        return userResponse;
    }


}
