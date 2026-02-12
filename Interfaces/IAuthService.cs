using UserApi.Application.DTO;

public interface IAuthService
{
    Task<AuthResponseDTO> Login(LoginRequestDTO request);
    Task Register(RegisterUserRequestDTO request);
}
