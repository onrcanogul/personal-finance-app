using PF.Common.Models.Token;
using PF.Domain.Entities.Identity;

namespace PF.Infrastructure;

public interface ITokenHandler
{
    Token CreateToken(User user);
}