using BLL;
using DAL;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _service;

        public ScheduleController(IScheduleService service)
        {
            _service = service;
        }

        // GET: api/Schedule
        [HttpGet("{doctorId}")]
        public async Task<ActionResult<IEnumerable<ScheduleDayDTO>>> GetSchedule(int doctorId)
        {
            return await _service.GetDoctorsScheduleDays(doctorId);
        }

        [HttpGet("{doctorId}/{dayId}")]
        public async Task<ActionResult<ScheduleDayDTO>> GetScheduleDay(int doctorId, int dayId)
        {
            return await _service.GetScheduleDay(doctorId, dayId);
        }
        [HttpPost]
        [Route("{doctorId}")]
        public async Task<ActionResult<ScheduleDayWithSlotsDTO>> GetScheduleDayWithOpens(int doctorId,[FromBody] ScheduleSlotsViewModel model)
        {
            return await _service.GetScheduleDayWithOpens(doctorId, model.ServiceId, model.Date);
        }

        [HttpPost]
        [Route("Edit/")]
        public async Task<IActionResult> EditSchedule([FromBody] ScheduleDaysViewModel ScheduleDaysViewModel)
        {
            bool edited = _service.EditDoctorsScheduleDays(ScheduleDaysViewModel.Schedule);
            var newSchedule = await _service.GetDoctorsScheduleDays(ScheduleDaysViewModel.Schedule[0].DoctorId);
            if (edited)
            {
                
                return Ok(new
                {
                    message = "Расписание обновлено",
                    schedule = newSchedule
                });
            }
            else
            {
                return BadRequest(new { error="yes", message = "Невозможно сохранить такое расписание. Существуют записи, на измененное рабочее время!", schedule = newSchedule });
            }
        }
    }
}
