using UserApi.Application.DTO;

namespace UserApi.Application.Services;
public interface IUserService
{
    UserResponseDTO CreateUser(UserRequestDTO requst);
    UserResponseDTO? GetUserById(Guid id);
    IEnumerable<UserResponseDTO> GetAllUsers();
    UserResponseDTO UpdateUser(Guid id, UserRequestDTO request);
    UserResponseDTO Patch(Guid id, UserPatchDTO request);
    void DeleteUser(Guid id);
}