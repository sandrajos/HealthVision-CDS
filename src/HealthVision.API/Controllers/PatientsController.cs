using Microsoft.AspNetCore.Mvc;
using HealthVision.Infrastructure.Data;
using HealthVision.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HealthVision.API.Controllers
{
    [ApiController]
    [Route("api/patients")]
    public class PatientsController : ControllerBase
    {
        private readonly HealthVisionDbContext _context;

        public PatientsController(HealthVisionDbContext context)
        {
            _context = context;
        }

        // GET: api/patients
        [HttpGet]
        public async Task<IActionResult> GetPatients()
        {
            var patients = await _context.Patients.ToListAsync();

            return Ok(patients);
        }

        // GET: api/patients/{id}
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetPatient(Guid id)
        {
            var patient = await _context.Patients.FindAsync(id);

            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }

        // POST: api/patients
        [HttpPost]
        public async Task<IActionResult> CreatePatient([FromBody] Patient patient)
        {
            _context.Patients.Add(patient);

            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetPatient),
                new { id = patient.Id },
                patient);
        }

        // PUT: api/patients/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdatePatient(
            Guid id,
            [FromBody] Patient updated)
        {
            var patient = await _context.Patients.FindAsync(id);

            if (patient == null)
            {
                return NotFound();
            }

            patient.PatientNumber = updated.PatientNumber;
            patient.Name = updated.Name;
            patient.Age = updated.Age;
            patient.Gender = updated.Gender;

            await _context.SaveChangesAsync();

            return Ok(patient);
        }

        // DELETE: api/patients/{id}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeletePatient(Guid id)
        {
            var patient = await _context.Patients.FindAsync(id);

            if (patient == null)
            {
                return NotFound();
            }

            _context.Patients.Remove(patient);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}