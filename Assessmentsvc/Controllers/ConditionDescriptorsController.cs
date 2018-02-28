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
    [Route("api/ConditionDescriptors")]
    public class ConditionDescriptorsController : Controller
    {
        private readonly AssessmentsContext _context;

        public ConditionDescriptorsController(AssessmentsContext context)
        {
            _context = context;
        }

        // GET: api/ConditionDescriptors
        [HttpGet]
        public IEnumerable<ConditionDescriptor> GetConditionDescriptors()
        {
            return _context.ConditionDescriptors;
        }

        // GET: api/ConditionDescriptors/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetConditionDescriptor([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var conditionDescriptor = await _context.ConditionDescriptors.SingleOrDefaultAsync(m => m.Id == id);

            if (conditionDescriptor == null)
            {
                return NotFound();
            }

            return Ok(conditionDescriptor);
        }

        // PUT: api/ConditionDescriptors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConditionDescriptor([FromRoute] Guid id, [FromBody] ConditionDescriptor conditionDescriptor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != conditionDescriptor.Id)
            {
                return BadRequest();
            }

            _context.Entry(conditionDescriptor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConditionDescriptorExists(id))
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

        // POST: api/ConditionDescriptors
        [HttpPost]
        public async Task<IActionResult> PostConditionDescriptor([FromBody] ConditionDescriptor conditionDescriptor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ConditionDescriptors.Add(conditionDescriptor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConditionDescriptor", new { id = conditionDescriptor.Id }, conditionDescriptor);
        }

        // DELETE: api/ConditionDescriptors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConditionDescriptor([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var conditionDescriptor = await _context.ConditionDescriptors.SingleOrDefaultAsync(m => m.Id == id);
            if (conditionDescriptor == null)
            {
                return NotFound();
            }

            _context.ConditionDescriptors.Remove(conditionDescriptor);
            await _context.SaveChangesAsync();

            return Ok(conditionDescriptor);
        }

        private bool ConditionDescriptorExists(Guid id)
        {
            return _context.ConditionDescriptors.Any(e => e.Id == id);
        }
    }
}