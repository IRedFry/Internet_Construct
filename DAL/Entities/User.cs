using Microsoft.AspNetCore.Identity;

namespace DAL
{
    /// <summary>
    /// Пользователь системы
    /// </summary>
    public class User : IdentityUser
    {
        public int UserId { get; set; } 
    }
}
