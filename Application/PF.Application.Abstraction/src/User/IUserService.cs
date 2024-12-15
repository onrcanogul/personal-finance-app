using PF.Application.Abstraction.src.User.Dto;
using PF.Common.Models.Response;
using PF.Common.Models.Token;

namespace PF.Application.Abstraction.src;

public interface IUserService
{
    Task<Response<Token>> Login(LoginDto dto);
    Task<Response<Token>> LoginWithRefreshToken(string refreshToken);
    Task<Response<NoContent>> Register(RegisterDto user);
}