using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApis.Constant.StringConstant;
using WebApis.Constant.UrlEndPoints;
using WebApis.Helpers;
using WebApis.Models.Dtos;
using WebApis.Services.UserServices;

namespace WebApis.Controllers.User
{

    [Route($"{UrlEndPoints.auth}/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private IMapper _mapper;
        public UserController(
       IUserService userService,
       IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost(UrlEndPoints.signUp)]
        public IActionResult Create(CreateUser userData)
        {
            var createdUser = _userService.createUser(userData);
            return Ok(new { message = StringConstant.userCreated, user = createdUser });
        }

        [HttpPost(UrlEndPoints.signIn)]
        public IActionResult SignIn(SignInUserRequest userData)
        {
            var user = _userService.signIn(userData);

            if (user == null)
                return Unauthorized(new { message = StringConstant.invalidCreds });

            return Ok(new { message = StringConstant.signInSuccess, user });
        }

        [Authorize]
        [HttpPost(UrlEndPoints.updateUser)]
        public IActionResult Update(UpdateUserRequest userData)
        {
            var authorizationResult = UserAuthorizationHelper.ValidateUserAuthorization(HttpContext, userData.Id);
            if (authorizationResult != null)
                return authorizationResult;
            _userService.updateUser(userData);
            return Ok(new { message = StringConstant.userUpdated });
        }

        [HttpPost(UrlEndPoints.refreshToken)]
        public IActionResult RefreshAccessToken(RefreshTokenRequest token)
        {
            var accessToken = _userService.refreshToken(token);
            return Ok(new { message = StringConstant.tokenUpdated, accessToken });
        }
    }



}