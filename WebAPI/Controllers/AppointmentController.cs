using BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    /// <summary>
    /// Контроллер записей
    /// </summary>
    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _service;

        public AppointmentController(IAppointmentService service)
        {
            _service = service;
        }
        /// <summary>
        /// Метод создания записи
        /// </summary>
        /// <param name="appointment">DTO записи</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "user")]
        public async Task<IActionResult> MakeAppointment([FromBody] AppointmentDTO appointment)
        {

            _service.CreateAppoitment(appointment);
            string time = ((int)appointment.StartTime.TotalHours).ToString() + ":00:00";

            return Created("", new { created = "yes", message = "Вы успешно записались на " + appointment.Date.Date.ToString("dd.mm.yyyy") + " " + time }) ;
        }
    }
}
