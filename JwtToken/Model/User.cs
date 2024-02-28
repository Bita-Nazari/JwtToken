using Microsoft.AspNetCore.Identity;

namespace JwtToken.Model
{
    public class User : IdentityUser<int>
    {
       
    }
    public class Role : IdentityRole<int>
    {

    }
}
