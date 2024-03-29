﻿using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL;
using BLL;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceService _service;

        public ServicesController(IServiceService service)
        {
            _service = service;
        }

        // GET: api/Services
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BLL.ServiceDTO>>> GetService()
        {
            return await _service.GetAllServices();
        }

        // GET: api/Services/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Service>> GetService(int id)
        {
            //if (_context.Service == null)
            //{
            //    return NotFound();
            //}
            //  var service = await _context.Service.FindAsync(id);

            //  if (service == null)
            //  {
            //      return NotFound();
            //  }
            return NoContent();
          //  return service;
        }

        // PUT: api/Services/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutService(int id, Service service)
        {
            //if (id != service.Id)
            //{
            //    return BadRequest();
            //}

            //_context.Entry(service).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!ServiceExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return NoContent();
        }

        // POST: api/Services
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Service>> PostService(Service service)
        {
          //if (_context.Service == null)
          //{
          //    return Problem("Entity set 'ClinicContext.Service'  is null.");
          //}
          //  _context.Service.Add(service);
          //  await _context.SaveChangesAsync();

            return CreatedAtAction("GetService", new { id = service.Id }, service);
        }

        // DELETE: api/Services/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            //if (_context.Service == null)
            //{
            //    return NotFound();
            //}
            //var service = await _context.Service.FindAsync(id);
            //if (service == null)
            //{
            //    return NotFound();
            //}

            //_context.Service.Remove(service);
            //await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiceExists(int id)
        {
            return false; // (_context.Service?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
