using BLL;
using DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace ASPNetCoreApp.Controllers
{
    [Produces("application/json")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IPatientService patientService;
        private readonly IDoctorService doctorService;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IPatientService patientService, IDoctorService doctorService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this.doctorService = doctorService;
            this.patientService = patientService;
        }
        [HttpPost]
        [Route("api/Account/Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                PatientDTO p = new PatientDTO
                {
                    DateOfBirth = model.Dob,
                    Name = model.Name,
                    Passport = model.Passport,
                    SerName = model.Sername,
                    Phone = model.Phone,
                };
                int id = patientService.CreatePatient(p);
                p.Id = id;
                User user = new() {UserId = id, Email = model.Email, UserName = model.Email };
                // Добавление нового пользователя
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // Установка роли User
                    await _userManager.AddToRoleAsync(user, "user");
                    // Установка куки
                    await _signInManager.SignInAsync(user, false);

                    return Ok(new { message = "Добавлен новый пользователь: " + user.UserName, patient = p});
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    var errorMsg = new
                    {
                        message = "Пользователь не добавлен",
                        error = ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage))
                    };
                    return Created("", errorMsg);
                }
            }
            else
            {
                var errorMsg = new
                {
                    message = "Неверные входные данные",
                    error = ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage))
                };
                return Created("", errorMsg);

            
            }
        }
        [HttpPost]
        [Route("api/Account/Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result =
                await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe,false);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(model.Email);
                    IList<string>? roles = await _userManager.GetRolesAsync(user);
                    string? userRole = roles.FirstOrDefault();

                    if (userRole == "user")
                    {
                        PatientDTO patient = patientService.GetPatient(user.UserId);
                        return Ok(new { message = "Выполнен вход", userName = model.Email, userRole, patient = patient });
                    }
                    else if (userRole == "doctor")
                    {
                        DoctorDTO doctor = await doctorService.GetDoctorById(user.UserId);
                        return Ok(new { message = "Выполнен вход", userName = model.Email, userRole, doctor = doctor });
                    }

                    return Unauthorized(new { message = "Неизвестная роль" });
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                    var errorMsg = new
                    {
                        message = "Вход не выполнен",
                        error = ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage))
                    };
                    return Created("", errorMsg);
                }
            }
            else
            {
                var errorMsg = new
                {
                    message = "Вход не выполнен",
                    error = ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage))
                };
                return Created("", errorMsg);
            }
        }
        [HttpPost]
        [Route("api/Account/Logoff")]
        public async Task<IActionResult> LogOff()
        {
            User usr = await GetCurrentUserAsync();
            if (usr == null)
            {
                return Unauthorized(new { message = "Сначала выполните вход" });
            }
            // Удаление куки
            await _signInManager.SignOutAsync();
            return Ok(new { message = "Выполнен выход", userName = usr.UserName });
        }
        [HttpGet]
        [Route("api/Account/IsAuthenticated")]
        public async Task<IActionResult> IsAuthenticated()
        {
            User usr = await GetCurrentUserAsync();
            if (usr == null)
            {
                return Unauthorized(new { message = "Вы Гость. Пожалуйста, выполните вход" });
            }
            IList<string> roles = await _userManager.GetRolesAsync(usr);
            string? userRole = roles.FirstOrDefault();
            if (userRole == "user")
            {
                PatientDTO patient = patientService.GetPatient(usr.UserId);
                return Ok(new { message = "Сессия активна, пациент", userName = usr.UserName, userRole, patient = patient });
            }
            else if (userRole == "doctor")
            {
                DoctorDTO doctor = await doctorService.GetDoctorById(usr.UserId);
                return Ok(new { message = "Сессия активна, пациент", userName = usr.UserName, userRole, doctor = doctor });
            }

            return Unauthorized(new { message = "Неизвестная роль" });

        }
        private Task<User> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}