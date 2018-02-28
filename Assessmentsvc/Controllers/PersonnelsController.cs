using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assessmentsvc.Database;
using Assessmentsvc.Database.Entity;

namespace Assessmentsvc.Controllers
{
    [Produces("application/json")]
    [Route("api/Personnels")]
    public class PersonnelsController : Controller
    {
        private readonly AssessmentsContext _context;

        public PersonnelsController(AssessmentsContext context)
        {
            _context = context;
        }

        // GET: api/Personnels
        [HttpGet]
        public IEnumerable<Personnel> GetPersonnelData()
        {
            return _context.PersonnelData;
        }

        // GET: api/Personnels/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonnel([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var personnel = await _context.PersonnelData.SingleOrDefaultAsync(m => m.Id == id);

            if (personnel == null)
            {
                return NotFound();
            }

            return Ok(personnel);
        }

        // PUT: api/Personnels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonnel([FromRoute] Guid id, [FromBody] Personnel personnel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personnel.Id)
            {
                return BadRequest();
            }

            _context.Entry(personnel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonnelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Personnels
        [HttpPost]
        public async Task<IActionResult> PostPersonnel([FromBody] Personnel personnel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PersonnelData.Add(personnel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonnel", new { id = personnel.Id }, personnel);
        }

        // DELETE: api/Personnels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonnel([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var personnel = await _context.PersonnelData.SingleOrDefaultAsync(m => m.Id == id);
            if (personnel == null)
            {
                return NotFound();
            }

            _context.PersonnelData.Remove(personnel);
            await _context.SaveChangesAsync();

            return Ok(personnel);
        }

        private bool PersonnelExists(Guid id)
        {
            return _context.PersonnelData.Any(e => e.Id == id);
        }
    }
}