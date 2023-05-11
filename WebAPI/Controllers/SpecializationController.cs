using BLL;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class SpecializationController : ControllerBase
    {
        private readonly ISpecializationService _service;

        public SpecializationController(ISpecializationService service)
        {
            _service = service;
        }
        // GET: api/<SpecializationController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BLL.SpecializationDTO>>> GetSpecialization()
        {
            return await _service.GetAllSpecialization();
        }

        // GET api/<SpecializationController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SpecializationController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SpecializationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SpecializationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
