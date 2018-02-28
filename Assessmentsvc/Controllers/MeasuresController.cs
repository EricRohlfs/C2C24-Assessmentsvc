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
    [Route("api/Measures")]
    public class MeasuresController : Controller
    {
        private readonly AssessmentsContext _context;

        public MeasuresController(AssessmentsContext context)
        {
            _context = context;
        }

        // GET: api/Measures
        [HttpGet]
        public IEnumerable<Measure> GetMeasures()
        {
            return _context.Measures;
        }

        // GET: api/Measures/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMeasure([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var measure = await _context.Measures.SingleOrDefaultAsync(m => m.Id == id);

            if (measure == null)
            {
                return NotFound();
            }

            return Ok(measure);
        }

        // PUT: api/Measures/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeasure([FromRoute] Guid id, [FromBody] Measure measure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != measure.Id)
            {
                return BadRequest();
            }

            _context.Entry(measure).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeasureExists(id))
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

        // POST: api/Measures
        [HttpPost]
        public async Task<IActionResult> PostMeasure([FromBody] Measure measure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Measures.Add(measure);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMeasure", new { id = measure.Id }, measure);
        }

        // DELETE: api/Measures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeasure([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var measure = await _context.Measures.SingleOrDefaultAsync(m => m.Id == id);
            if (measure == null)
            {
                return NotFound();
            }

            _context.Measures.Remove(measure);
            await _context.SaveChangesAsync();

            return Ok(measure);
        }

        private bool MeasureExists(Guid id)
        {
            return _context.Measures.Any(e => e.Id == id);
        }
    }
}