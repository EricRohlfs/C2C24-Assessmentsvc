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
    [Route("api/Sorts")]
    public class SortsController : Controller
    {
        private readonly AssessmentsContext _context;

        public SortsController(AssessmentsContext context)
        {
            _context = context;
        }

        // GET: api/Sorts
        [HttpGet]
        public IEnumerable<Sorts> GetSortsAssessments()
        {
            return _context.SortsAssessments;
        }

        // GET: api/Sorts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSorts([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sorts = await _context.SortsAssessments.SingleOrDefaultAsync(m => m.Id == id);

            if (sorts == null)
            {
                return NotFound();
            }

            return Ok(sorts);
        }

        // PUT: api/Sorts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSorts([FromRoute] Guid id, [FromBody] Sorts sorts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sorts.Id)
            {
                return BadRequest();
            }

            _context.Entry(sorts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SortsExists(id))
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

        // POST: api/Sorts
        [HttpPost]
        public async Task<IActionResult> PostSorts([FromBody] Sorts sorts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SortsAssessments.Add(sorts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSorts", new { id = sorts.Id }, sorts);
        }

        // DELETE: api/Sorts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSorts([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sorts = await _context.SortsAssessments.SingleOrDefaultAsync(m => m.Id == id);
            if (sorts == null)
            {
                return NotFound();
            }

            _context.SortsAssessments.Remove(sorts);
            await _context.SaveChangesAsync();

            return Ok(sorts);
        }

        private bool SortsExists(Guid id)
        {
            return _context.SortsAssessments.Any(e => e.Id == id);
        }
    }
}