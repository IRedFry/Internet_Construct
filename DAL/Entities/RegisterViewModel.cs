using System.ComponentModel.DataAnnotations;

namespace DAL
{
    /// <summary>
    /// Модель данных для формы регистрации
    /// </summary>
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Sername")]
        public string Sername { get; set; }
        [Required]
        [Display(Name = "Dob")]
        public DateTime Dob { get; set; }
        [Required]
        [Display(Name = "Passport")]
        public string Passport { get; set; }
        [Required]
        [Display(Name = "Phone")]
        public string Phone { get; set; }
    }
}
