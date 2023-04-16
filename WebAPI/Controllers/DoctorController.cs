using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Data;
using WebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly ClinicContext _context;

        public DoctorController(ClinicContext context)
        {
            _context = context;
        }
        // GET: api/<DoctorController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctor()
        {
            return await _context.Doctor.Include(p => p.Specialization).ToListAsync();
        }

        // GET api/<DoctorController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> GetDoctor(int id)
        {
            var doctor = await _context.Doctor.FindAsync(id);

            if (doctor == null)
                return NotFound();

            return doctor;
        }

        // POST api/<DoctorController>
        [HttpPost]
        public async Task<ActionResult<Doctor>> PostDoctor(DoctorDTO doctor) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var doc = new Doctor
            {
                Id = doctor.Id,
                Name = doctor.Name,
                Sername = doctor.Sername,
                SpecializationId = doctor.SpecializationId,
                ScheduleId = doctor.ScheduleId,
                Salary = doctor.Salary,
                StartDate = doctor.StartDate,
                Appointment = new List<Appointment>(),
                Login = doctor.Login,
                Password = doctor.Password,
                Specialization = _context.Specialization.Find(doctor.SpecializationId),
                ScheduleWeek = new List<ScheduleWeek>()
            };
            _context.Doctor.Add(doc);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDoctor", new {id = doctor.Id}, doctor);
        }

        // PUT api/<DoctorController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoctor(int id, Doctor doctor) 
        {
            if (id != doctor.Id)
                return BadRequest();

            _context.Entry(doctor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        private bool DoctorExists(int id)
        {
            return _context.Doctor.Any(e => e.Id == id);
        }

        // DELETE api/<DoctorController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var doctor = await _context.Doctor.FindAsync(id);
            if(doctor == null)
                return NotFound();

            _context.Doctor.Remove(doctor);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
