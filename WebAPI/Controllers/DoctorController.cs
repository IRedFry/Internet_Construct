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
    /// <summary>
    /// Контроллер врачей
    /// </summary>
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
        /// <summary>
        /// Метод получение всех врачей
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BLL.DoctorDTO>>> GetDoctor()
        {
            return await _service.GetAllDoctors();
        }

        /// <summary>
        /// Метод получения врача по id
        /// </summary>
        /// <param name="id">Id врача</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<BLL.DoctorDTO>> GetDoctor(int id)
        {
            var doctor = await _service.GetDoctorById(id);

            if (doctor == null)
                return NotFound();

            return doctor;
        }

        /// <summary>
        /// Метод получения всех врачей данной специальности
        /// </summary>
        /// <param name="specializationId">Id специальности</param>
        /// <returns></returns>
        [HttpGet("specialization/{specializationId}")]
        public async Task<ActionResult<IEnumerable<BLL.DoctorDTO>>> GetDoctorsBySpecialization(int specializationId)
        {
            return await _service.GetDoctorsBySpecialization(specializationId);
        }

    }
}
