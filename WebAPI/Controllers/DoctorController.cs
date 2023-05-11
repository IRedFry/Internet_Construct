using BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _service;

        public DoctorController(IDoctorService service)
        {
            _service = service;
        }
        // GET: api/<DoctorController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BLL.DoctorDTO>>> GetDoctor()
        {
            return await _service.GetAllDoctors();
        }

        // GET api/<DoctorController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BLL.DoctorDTO>> GetDoctor(int id)
        {
            var doctor = await _service.GetDoctorById(id);

            if (doctor == null)
                return NotFound();

            return doctor;
        }

        // GET api/<DoctorController>/specialization/1
        [HttpGet("specialization/{specializationId}")]
        public async Task<ActionResult<IEnumerable<BLL.DoctorDTO>>> GetDoctorsBySpecialization(int specializationId)
        {
            return await _service.GetDoctorsBySpecialization(specializationId);
        }

        // POST api/<DoctorController>
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<BLL.DoctorDTO>> PostDoctor(BLL.DoctorDTO doctor) 
        {
            doctor = await _service.GetDoctorById(doctor.Id);
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);
            //var doc = new Doctor
            //{
            //    Id = doctor.Id,
            //    Name = doctor.Name,
            //    Sername = doctor.Sername,
            //    SpecializationId = doctor.SpecializationId,
            //    ScheduleId = doctor.ScheduleId,
            //    Salary = doctor.Salary,
            //    StartDate = doctor.StartDate,
            //    Appointment = new List<Appointment>(),
            //    Specialization = _context.Specialization.Find(doctor.SpecializationId),
            //    ScheduleDay = new List<ScheduleDay>()
            //};
            //_context.Doctor.Add(doc);
            //await _context.SaveChangesAsync();

            return CreatedAtAction("GetDoctor", new {id = doctor.Id}, doctor);
        }

        // PUT api/<DoctorController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoctor(int id, BLL.DoctorDTO doctor) 
        {
            //if (id != doctor.Id)
            //    return BadRequest();

            //_context.Entry(doctor).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!DoctorExists(id))
            //        return NotFound();
            //    else
            //        throw;
            //}

            return NoContent();
        }

        private bool DoctorExists(int id)
        {
            return false; // _context.Doctor.Any(e => e.Id == id);
        }

        // DELETE api/<DoctorController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            //var doctor = await _context.Doctor.FindAsync(id);
            //if(doctor == null)
            //    return NotFound();

            //_context.Doctor.Remove(doctor);
            //await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
