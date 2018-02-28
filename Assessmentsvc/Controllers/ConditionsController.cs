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
    [Route("api/Conditions")]
    public class ConditionsController : Controller
    {
        private readonly AssessmentsContext _context;

        public ConditionsController(AssessmentsContext context)
        {
            _context = context;
        }

        // GET: api/Conditions
        [HttpGet]
        public IEnumerable<Condition> GetConditions()
        {
            return _context.Conditions;
        }

        // GET: api/Conditions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCondition([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var condition = await _context.Conditions.SingleOrDefaultAsync(m => m.Id == id);

            if (condition == null)
            {
                return NotFound();
            }

            return Ok(condition);
        }

        // PUT: api/Conditions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCondition([FromRoute] Guid id, [FromBody] Condition condition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != condition.Id)
            {
                return BadRequest();
            }

            _context.Entry(condition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConditionExists(id))
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

        // POST: api/Conditions
        [HttpPost]
        public async Task<IActionResult> PostCondition([FromBody] Condition condition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Conditions.Add(condition);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCondition", new { id = condition.Id }, condition);
        }

        // DELETE: api/Conditions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCondition([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var condition = await _context.Conditions.SingleOrDefaultAsync(m => m.Id == id);
            if (condition == null)
            {
                return NotFound();
            }

            _context.Conditions.Remove(condition);
            await _context.SaveChangesAsync();

            return Ok(condition);
        }

        private bool ConditionExists(Guid id)
        {
            return _context.Conditions.Any(e => e.Id == id);
        }
    }
}