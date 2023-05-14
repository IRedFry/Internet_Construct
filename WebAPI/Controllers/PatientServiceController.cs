using BLL;
using BLL.Models;
using DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class PatientServiceController : ControllerBase
    {
        private readonly IAppointmentService _service;

        public PatientServiceController(IAppointmentService service)
        {
            _service = service;
        }

        // GET: api/PatientService
        [HttpGet("Present/{id}")]
        public async Task<ActionResult<IEnumerable<PatientServiceDTO>>> GetDoctorPresentService(int id)
        {
            return await _service.GetPresentPatientService(id);
        }

        [HttpGet("Already/{id}")]
        public async Task<ActionResult<IEnumerable<PatientServiceDTO>>> GetDoctorAlreadyService(int id)
        {
            return await _service.GetAlreadyPatientService(id);
        }

        [HttpPost("Refuse/{id}")]
        [Authorize(Roles = "user")]
        public async Task<ActionResult> RefuseAppointment(int id, [FromBody] int statusId)
        {
            _service.ChangeAppointmentStatus(id, statusId);
            return Ok(new { message = "Запись отклонена по собственному желанию"});
        }
    }
}
