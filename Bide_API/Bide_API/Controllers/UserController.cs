using Bide_API.Models;
using Bide_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bide_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : Controller {
    private readonly IUserService _userService;
    private readonly IAuthService _authService;

    public UserController(IUserService userService, IAuthService authService) {
        _userService = userService;
        _authService = authService;
    }
    
    [HttpPost("Login")]
    public async Task<LoginInfo> Login(User user) {
        var loginResult =  await _userService.Login(user.userId, user.password);
        var cookieOptions = new CookieOptions {
            Expires = DateTimeOffset.UtcNow.AddDays(7)
        };
        if (loginResult.message == "Success") {
            Response.Cookies.Append("token", _authService.GenerateToken(user.userId));
        }

        return loginResult;
    }

    [HttpPost("Create")]
    public string CreateAccount(User user) {
        
    }
}