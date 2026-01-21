using UserApi.Application.DTO;
using UserApi.Domain;

namespace UserApi.Application.Services;
public interface IUserService
{
    UserResponseDTO CreateUser(UserRequestDTO requst);
    UserResponseDTO? GetUserById(Guid id);
    IEnumerable<UserResponseDTO> GetAllUsers();
    void DeleteUser(Guid id);
}