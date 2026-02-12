using Microsoft.AspNetCore.Identity;
using UserApi.Application.DTO;
using UserApi.Domain;
using UserApi.Security;

namespace UserApi.Application.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly JwtTokenGenerator _jwt;

    public AuthService(UserManager<AppUser> userManager, JwtTokenGenerator jwt)
    {
        _userManager = userManager;
        _jwt = jwt;
    }

    public async Task Register(RegisterUserRequestDTO request)
    {
        var user = new AppUser
        {
            UserName = request.Email,
            Email = request.Email
        };

        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));
        }
    }

    public async Task<AuthResponseDTO> Login(LoginRequestDTO request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null) return null!;

        var passwordValid = await _userManager.CheckPasswordAsync(user, request.Password);
        if (!passwordValid) return null!;

        var token = _jwt.Generate(user);

        return new AuthResponseDTO { Token = token };
    }
}
