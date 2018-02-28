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
    [Route("api/AssessmentComments")]
    public class AssessmentCommentsController : Controller
    {
        private readonly AssessmentsContext _context;

        public AssessmentCommentsController(AssessmentsContext context)
        {
            _context = context;
        }

        // GET: api/AssessmentComments
        [HttpGet]
        public IEnumerable<AssessmentComment> GetAssessmentComments()
        {
            return _context.AssessmentComments;
        }

        // GET: api/AssessmentComments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAssessmentComment([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var assessmentComment = await _context.AssessmentComments.SingleOrDefaultAsync(m => m.Id == id);

            if (assessmentComment == null)
            {
                return NotFound();
            }

            return Ok(assessmentComment);
        }

        // PUT: api/AssessmentComments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssessmentComment([FromRoute] Guid id, [FromBody] AssessmentComment assessmentComment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != assessmentComment.Id)
            {
                return BadRequest();
            }

            _context.Entry(assessmentComment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssessmentCommentExists(id))
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

        // POST: api/AssessmentComments
        [HttpPost]
        public async Task<IActionResult> PostAssessmentComment([FromBody] AssessmentComment assessmentComment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.AssessmentComments.Add(assessmentComment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssessmentComment", new { id = assessmentComment.Id }, assessmentComment);
        }

        // DELETE: api/AssessmentComments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssessmentComment([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var assessmentComment = await _context.AssessmentComments.SingleOrDefaultAsync(m => m.Id == id);
            if (assessmentComment == null)
            {
                return NotFound();
            }

            _context.AssessmentComments.Remove(assessmentComment);
            await _context.SaveChangesAsync();

            return Ok(assessmentComment);
        }

        private bool AssessmentCommentExists(Guid id)
        {
            return _context.AssessmentComments.Any(e => e.Id == id);
        }
    }
}