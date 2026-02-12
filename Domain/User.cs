// namespace UserApi.Domain;
// public class User
// {
//     public Guid Id { get; private set; }
//     public string Name { get; private set; } = default!;
//     public int Age { get; private set; }
//     public string Email { get; private set; } = default!;
//     public string Password { get; private set; } = default!;



 

//     private User() { } // EF Core needs this
//     public User(string name, int age, string email, string password) //normal constructor creation
//     {
//         Update(name, age, email); // using the validation logic in Update
//         SetPasswordHash(password);

//         Id = Guid.NewGuid();
//         Name = name;
//         Age = age;
//         Email = email;
//         Password = password;
//     }

//     public User(string name, int age, string email)
//     {
//         Name = name;
//         Age = age;
//         Email = email;
//     }

//     private void SetPasswordHash(string password)
//     {
//         if (string.IsNullOrWhiteSpace(password))
//             throw new ArgumentException("Password hash is required");

//         Password = password;
//     }



//     public void Update(string name, int age, string email)
//     {
//         if (string.IsNullOrWhiteSpace(name))
//             throw new ArgumentNullException("Name is required", nameof(name));

//         if (string.IsNullOrWhiteSpace(email))
//             throw new ArgumentNullException("Email is required", nameof(email));

//         if (age < 12)
//             throw new ArgumentOutOfRangeException("Age must be 12years or older", nameof(age));

//         Name = name;
//         Age = age;
//         Email = email;
        
//     }
    

//     public void Patch(string? name, int? age, string? email)
//     {
//         if (name is not null)
//         {
//             if (string.IsNullOrWhiteSpace(name))
//                 throw new ArgumentNullException("this can't be empty[PATCH]", nameof(name));
//             Name = name;
//         }

//         if (age.HasValue)
//         {
//             if (age < 12)
//                 throw new Exception("this age is out of range[PATCH]");
//             Age = age.Value;
//         }

//         if (email is not null)
//         {
//             if (string.IsNullOrWhiteSpace(email))
//                 throw new ArgumentNullException("this email field can't be empty[PATCH]", nameof(email));

//             Email = email;
//         }
//     }
// }