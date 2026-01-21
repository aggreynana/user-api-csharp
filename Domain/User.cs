namespace UserApi.Domain;
public class User
{
    public Guid Id { get; }
    public string Name { get; private set; } = null!;
    public int Age { get; private set; }
    public string Email { get; private set; } = null!;

    public User(string name, int age, string email)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException("Name is required", nameof(name));

        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentNullException("Email is required", nameof(email));

        if (age < 12)
            throw new ArgumentOutOfRangeException("Age must be 12years or older", nameof(age));

        Id = Guid.NewGuid();
        Name = name;
        Age = age;
        Email = email;
    }

    

    public void Update(string name, int age, string email)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException("Name is required", nameof(name));

        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentNullException("Email is required", nameof(email));

        if (age < 12)
            throw new ArgumentOutOfRangeException("Age must be 12years or older", nameof(age));

        Name = name;
        Age = age;
        Email = email;
    }
}