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
    [Route("api/Missions")]
    public class MissionsController : Controller
    {
        private readonly AssessmentsContext _context;

        public MissionsController(AssessmentsContext context)
        {
            _context = context;
        }

        // GET: api/Missions
        [HttpGet]
        public IEnumerable<Mission> GetMissions()
        {
            return _context.Missions;
        }

        // GET: api/Missions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMission([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mission = await _context.Missions.SingleOrDefaultAsync(m => m.Id == id);

            if (mission == null)
            {
                return NotFound();
            }

            return Ok(mission);
        }

        // PUT: api/Missions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMission([FromRoute] Guid id, [FromBody] Mission mission)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mission.Id)
            {
                return BadRequest();
            }

            _context.Entry(mission).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MissionExists(id))
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

        // POST: api/Missions
        [HttpPost]
        public async Task<IActionResult> PostMission([FromBody] Mission mission)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Missions.Add(mission);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMission", new { id = mission.Id }, mission);
        }

        // DELETE: api/Missions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMission([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mission = await _context.Missions.SingleOrDefaultAsync(m => m.Id == id);
            if (mission == null)
            {
                return NotFound();
            }

            _context.Missions.Remove(mission);
            await _context.SaveChangesAsync();

            return Ok(mission);
        }

        private bool MissionExists(Guid id)
        {
            return _context.Missions.Any(e => e.Id == id);
        }
    }
}