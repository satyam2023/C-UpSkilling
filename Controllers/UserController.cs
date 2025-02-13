using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApis.Helpers;
using WebApis.Models.Dtos;
using WebApis.Services.UserServices;

namespace WebApis.Controllers.User{


[Route("auth/[controller]")]
[ApiController]
public class UserController:ControllerBase{
 private IUserService _userService;
    private IMapper _mapper;
         public UserController(
        IUserService userService,
        IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

 [HttpPost("signUp")]
    public IActionResult Create(CreateUser userData)
    {
       var createdUser= _userService.createUser(userData);
        return Ok(new { message = "User created",user = createdUser });
    }

[HttpPost("signIn")]
 
 public IActionResult SignIn(SignInUserRequest userData){
     var user = _userService.signIn(userData);

            if (user == null)
                return Unauthorized(new { message = "Invalid credentials" });

            return Ok(new { message = "Sign in successful",user});
 }
 

 [HttpPost("updateUser")]
 public IActionResult Update(UpdateUserRequest userData){
   _userService.updateUser(userData);
    return Ok(new { message = "User Updated Successfully"});
 }
}



}