using BLL;
using DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class DoctorServiceController : ControllerBase
    {
        private readonly IAppointmentService _service;

        public DoctorServiceController(IAppointmentService service)
        {
            _service = service;
        }

        // GET: api/DoctorService
        [HttpGet("Present/{id}")]
        public async Task<ActionResult<IEnumerable<DoctorServiceDTO>>> GetDoctorPresentService(int id)
        {
            return await _service.GetPresentDoctorService(id);
        }

        [HttpGet("Already/{id}")]
        public async Task<ActionResult<IEnumerable<DoctorServiceDTO>>> GetDoctorAlreadyService(int id)
        {
            return await _service.GetAlreadyDoctorService(id);
        }

        [HttpPost("Conclusion/{id}")]
        [Authorize(Roles = "doctor")]
        public async Task<ActionResult> RefuseAppointment(int id, [FromBody] string conclustion)
        {
            bool res = _service.SetAppointmentConclusion(id, conclustion);
            if (res)
                return Ok(new { message = "Запись получила заключение" });
            else
            {
                return BadRequest(new { error = "yes", message = "Нельзя поставить заключение приему, которого еще не было" });
            }
        }


    }
}
