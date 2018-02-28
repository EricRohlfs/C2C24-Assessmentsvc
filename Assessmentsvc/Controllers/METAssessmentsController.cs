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
    [Route("api/METAssessments")]
    public class METAssessmentsController : Controller
    {
        private readonly AssessmentsContext _context;

        public METAssessmentsController(AssessmentsContext context)
        {
            _context = context;
        }

        // GET: api/METAssessments
        [HttpGet]
        public IEnumerable<METAssessment> GetMETAssessments()
        {
            return _context.METAssessments;
        }

        // GET: api/METAssessments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMETAssessment([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mETAssessment = await _context.METAssessments.SingleOrDefaultAsync(m => m.Id == id);

            if (mETAssessment == null)
            {
                return NotFound();
            }

            return Ok(mETAssessment);
        }

        // PUT: api/METAssessments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMETAssessment([FromRoute] Guid id, [FromBody] METAssessment mETAssessment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mETAssessment.Id)
            {
                return BadRequest();
            }

            _context.Entry(mETAssessment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!METAssessmentExists(id))
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

        // POST: api/METAssessments
        [HttpPost]
        public async Task<IActionResult> PostMETAssessment([FromBody] METAssessment mETAssessment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.METAssessments.Add(mETAssessment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMETAssessment", new { id = mETAssessment.Id }, mETAssessment);
        }

        // DELETE: api/METAssessments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMETAssessment([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mETAssessment = await _context.METAssessments.SingleOrDefaultAsync(m => m.Id == id);
            if (mETAssessment == null)
            {
                return NotFound();
            }

            _context.METAssessments.Remove(mETAssessment);
            await _context.SaveChangesAsync();

            return Ok(mETAssessment);
        }

        private bool METAssessmentExists(Guid id)
        {
            return _context.METAssessments.Any(e => e.Id == id);
        }
    }
}