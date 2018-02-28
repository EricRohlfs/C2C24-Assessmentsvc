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
    [Route("api/CapabilityAssessments")]
    public class CapabilityAssessmentsController : Controller
    {
        private readonly AssessmentsContext _context;

        public CapabilityAssessmentsController(AssessmentsContext context)
        {
            _context = context;
        }

        // GET: api/CapabilityAssessments
        [HttpGet]
        public IEnumerable<CapabilityAssessment> GetCapabilityAssessments()
        {
            var assessments = _context.CapabilityAssessments.Include(assessment => assessment.METAssessments).ToList();
            return assessments;
        }

        // GET: api/CapabilityAssessments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCapabilityAssessment([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var capabilityAssessment = await _context.CapabilityAssessments.SingleOrDefaultAsync(m => m.Id == id);

            if (capabilityAssessment == null)
            {
                return NotFound();
            }

            return Ok(capabilityAssessment);
        }

        // PUT: api/CapabilityAssessments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCapabilityAssessment([FromRoute] Guid id, [FromBody] CapabilityAssessment capabilityAssessment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != capabilityAssessment.Id)
            {
                return BadRequest();
            }

            _context.Entry(capabilityAssessment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CapabilityAssessmentExists(id))
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

        // POST: api/CapabilityAssessments
        [HttpPost]
        public async Task<IActionResult> PostCapabilityAssessment([FromBody] CapabilityAssessment capabilityAssessment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CapabilityAssessments.Add(capabilityAssessment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCapabilityAssessment", new { id = capabilityAssessment.Id }, capabilityAssessment);
        }

        // DELETE: api/CapabilityAssessments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCapabilityAssessment([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var capabilityAssessment = await _context.CapabilityAssessments.SingleOrDefaultAsync(m => m.Id == id);
            if (capabilityAssessment == null)
            {
                return NotFound();
            }

            _context.CapabilityAssessments.Remove(capabilityAssessment);
            await _context.SaveChangesAsync();

            return Ok(capabilityAssessment);
        }

        private bool CapabilityAssessmentExists(Guid id)
        {
            return _context.CapabilityAssessments.Any(e => e.Id == id);
        }
    }
}