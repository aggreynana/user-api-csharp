using UserApi.Domain;
namespace UserApi.Repository;

public class UserRepository : IUserRepository
{
    private readonly List<User> _user = new();

    public void AddUser(User user) => _user.Add(user);
    public User? GetById(Guid id) => _user.FirstOrDefault(u => u.Id == id);
    public IEnumerable<User> GetAll() => _user;
    public void Delete(Guid id)
    {
        var user = GetById(id);
        
        if (user is not null) _ = _user.Remove(user);
   }
}