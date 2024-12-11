using Microsoft.AspNetCore.Mvc;
using PF.Application.Abstraction.src;
using PF.Application.Abstraction.src.User.Dto;
using PF.WebAPI.Controllers.Base;

namespace PF.WebAPI.Controllers;

public class UserController(IUserService service) : BaseController
{
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
        => ApiResult(await service.Login(dto));
    
    [HttpPost("refresh-token-login")]
    public async Task<IActionResult> RefreshTokenLogin([FromBody] string refreshToken)
        => ApiResult(await service.LoginWithRefreshToken(refreshToken));
    
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserDto user)
        => ApiResult(await service.Register(user));
}