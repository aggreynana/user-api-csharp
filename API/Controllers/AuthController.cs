using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserApi.Application.DTO;
using UserApi.Domain;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IAuthService _authService;

    public AuthController(
        UserManager<AppUser> userManager,
        IAuthService authService)
    {
        _userManager = userManager;
        _authService = authService;
    }

    // ------------------------
    // Registration Endpoint
    // ------------------------
    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserRequestDTO dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = new AppUser
        {
            UserName = dto.Email,
            Email = dto.Email,
            NormalizedUserName = dto.Name,
            Age = dto.Age
        };

        var result = await _userManager.CreateAsync(user, dto.Password);

        if (!result.Succeeded)
            return BadRequest(result.Errors);

        return Ok(new { message = "User registered successfully" });
    }

    // ------------------------
    // Login Endpoint
    // ------------------------
    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequestDTO request)
    {
        var result = await _authService.Login(request);

        if (result is null)
            return Unauthorized(new { Message = "Invalid credentials" });

        return Ok(result);
    }
}
