namespace PF.Application.Abstraction.src.User.Dto;

public class RegisterDto
{
    public string Email { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string ConfirmPassword { get; set; } = null!;
}