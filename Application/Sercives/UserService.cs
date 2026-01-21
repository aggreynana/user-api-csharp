using UserApi.Application.DTO;
using UserApi.Domain;
using UserApi.Repository;

namespace UserApi.Application.Services;
public class UserService : IUserService
{
    private readonly IUserRepository _repo;
    public UserService(IUserRepository repo)
    {
        _repo = repo;
    }

    public UserResponseDTO CreateUser(UserRequestDTO request)
    {
        var user = new User(request.Name, request.Age, request.Email );
        _repo.AddUser(user);

        return MapToDTO(user);
        
    }

    public UserResponseDTO? GetUserById(Guid id)
    {
        var user = _repo.GetById(id)
        ?? throw new KeyNotFoundException("the user is not found");

        return MapToDTO(user);
    }

    public IEnumerable<UserResponseDTO> GetAllUsers()
    {
        return _repo.GetAll().Select(MapToDTO);
    }

    public void DeleteUser(Guid id)
    {
        _= _repo.GetById(id)
        ?? throw new KeyNotFoundException("the user is not found");

        _repo.Delete(id);
    }

    private static UserResponseDTO MapToDTO(User user)
    {
        return new UserResponseDTO
        {
            Id = user.Id,
            Name = user.Name,
            Age = user.Age,
            Email = user.Email
        };
    }
}