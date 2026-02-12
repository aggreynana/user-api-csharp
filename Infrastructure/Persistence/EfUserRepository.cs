// using UserApi.Domain;
// using UserApi.Interface;

// public class EfUserRepository : IUserRepository
// {
//     private readonly AppDbContext _context;

//     public EfUserRepository(AppDbContext context)
//     {
//         _context = context;
//     }

//     public void AddUser(User user) => _context.Users.Add(user);
//     public User? GetById(Guid id) => _context.Users.Find(id);
//     public User? GetByEmail(string email) => _context.Users.FirstOrDefault(u => u.Email == email);
//     public IEnumerable<User> GetAll() => _context.Users.ToList();
//     public void Delete(Guid id)
//     {
//         var user = _context.Users.Find(id);
//         if (user != null) _context.Users.Remove(user);
//     }
//     public void SaveChanges() => _context.SaveChanges();
// }
