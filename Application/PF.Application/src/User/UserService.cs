using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using PF.Application.Abstraction.Report;
using PF.Application.Abstraction.src;
using PF.Application.Abstraction.src.User.Dto;
using PF.Common.Exceptions;
using PF.Common.Models.Response;
using PF.Common.Models.Token;
using PF.Domain.Entities.Identity;
using PF.Infrastructure;

namespace PF.Application.src;

public class UserService(UserManager<User> service, ITokenHandler tokenHandler, IMapper mapper, IHttpContextAccessor httpContextAccessor, IStringLocalizer localizer, IReportService reportService)
    : IUserService
{
    public string? GetCurrentUsername() => httpContextAccessor.HttpContext?.User.Identity!.Name;
    public async Task<Response<Token>> Login(LoginDto dto)
    {
        var user = await service.FindByNameAsync(dto.UsernameOrEmail) ?? await service.FindByEmailAsync(dto.UsernameOrEmail);
        if (user == null)
            throw new BadRequestException("Invalid username or password");
        var result = await service.CheckPasswordAsync(user, dto.Password);
        if (!result)
            return Response<Token>.Failure(localizer["UserNotFound"].Value, StatusCodes.Status400BadRequest);
        var token = tokenHandler.CreateToken(user);
        await UpdateRefreshTokenAsync(token.RefreshToken!, user, token.Expiration, 30);
        return Response<Token>.Success(token, StatusCodes.Status200OK);
    }
    public async Task<Response<Token>> LoginWithRefreshToken(string refreshToken)
    {
        var user = await service.Users.FirstOrDefaultAsync(x => x.RefreshToken == refreshToken);
        if (user == null) throw new NotFoundException(localizer["UserNotFound"].Value);
        var token = tokenHandler.CreateToken(user);
        await UpdateRefreshTokenAsync(refreshToken, user, token.Expiration, 10);
        return Response<Token>.Success(token, StatusCodes.Status200OK);
    }

    public async Task<Response<NoContent>> Register(RegisterDto user)
    {
        
        var isExist = await service.FindByNameAsync(user.Username);
        if(isExist != null) throw new BadRequestException("User already exists.");
        var newUser = new User { UserName = user.Username, Email = user.Email };
        await service.CreateAsync(newUser, user.Password);
        var response = (await service.CreateAsync(mapper.Map<User>(user), user.Password)).Succeeded ? 
            Response<NoContent>.Success(StatusCodes.Status201Created)
            : Response<NoContent>.Failure(localizer["RegisterFailure"].Value, StatusCodes.Status400BadRequest);
        if (response.IsSuccessful)
        {
            var registeredUser = await service.FindByNameAsync(user.Username);
            await reportService.CreateAsync(new() 
                { 
                    UserId = registeredUser.Id, 
                    User = mapper.Map<UserDto>(registeredUser)
                });
        }
            
        return response;
    }
    private async Task UpdateRefreshTokenAsync(string refreshToken, User user, DateTime accessTokenDate, int addToAccessToken)
    {
        if(user == null) throw new NotFoundException(localizer["UserNotFound"].Value);
        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiration = accessTokenDate.AddMinutes(addToAccessToken);
        await service.UpdateAsync(user);
    }
}