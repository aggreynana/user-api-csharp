using UserApi.Domain;

namespace UserApi.Repository;
public interface IUserRepository
{
    void AddUser(User user);
    User? GetById(Guid id);
    IEnumerable<User> GetAll();
    void Delete(Guid id);
    
}