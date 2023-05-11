using Microsoft.AspNetCore.Identity;

namespace DAL
{
    public class User : IdentityUser
    {
        public bool IsDoctor { get; set; }
        public bool IsPatient { get; set; }
        public int UserId { get; set; } 
    }
}
