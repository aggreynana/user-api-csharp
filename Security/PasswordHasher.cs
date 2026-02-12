// using Microsoft.AspNetCore.Identity;

// public class PasswordHasher
// {
//     private readonly PasswordHasher<IdentityBuilder> _hasher = new();

//     public string Hash(string password) =>
//         _hasher.HashPassword(null!, password);

//     public bool Verify(string hash, string password) =>
//         _hasher.VerifyHashedPassword(null!, hash, password)
//         == PasswordVerificationResult.Success;

//     internal bool Verify(object passwordHash, string password)
//     {
//         throw new NotImplementedException();
//     }
// }
