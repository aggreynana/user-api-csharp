using Microsoft.AspNetCore.Identity;

namespace UserApi.Domain;
public class AppUser : IdentityUser
{
    public int Age { get; set; }
}