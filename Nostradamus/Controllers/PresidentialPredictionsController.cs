using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nostradamus;
using Nostradamus.Models;

namespace Nostradamus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresidentialPredictionsController : ControllerBase
    {
        private readonly NostradamusContext _context;

        public PresidentialPredictionsController(NostradamusContext context)
        {
            _context = context;
        }

        // GET: api/PresidentialPredictions
        [HttpGet]
        public IEnumerable<PresidentialPrediction> GetPresidentialPrediction()
        {
            return _context.PresidentialPrediction;
        }

        // GET: api/PresidentialPredictions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPresidentialPrediction([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var presidentialPrediction = await _context.PresidentialPrediction.FindAsync(id);

            if (presidentialPrediction == null)
            {
                return NotFound();
            }

            return Ok(presidentialPrediction);
        }

        // PUT: api/PresidentialPredictions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPresidentialPrediction([FromRoute] int id, [FromBody] PresidentialPrediction presidentialPrediction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != presidentialPrediction.Id)
            {
                return BadRequest();
            }

            _context.Entry(presidentialPrediction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PresidentialPredictionExists(id))
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

        // POST: api/PresidentialPredictions
        [HttpPost]
        public async Task<IActionResult> PostPresidentialPrediction([FromBody] PresidentialPrediction presidentialPrediction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PresidentialPrediction.Add(presidentialPrediction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPresidentialPrediction", new { id = presidentialPrediction.Id }, presidentialPrediction);
        }

        // DELETE: api/PresidentialPredictions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePresidentialPrediction([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var presidentialPrediction = await _context.PresidentialPrediction.FindAsync(id);
            if (presidentialPrediction == null)
            {
                return NotFound();
            }

            _context.PresidentialPrediction.Remove(presidentialPrediction);
            await _context.SaveChangesAsync();

            return Ok(presidentialPrediction);
        }

        private bool PresidentialPredictionExists(int id)
        {
            return _context.PresidentialPrediction.Any(e => e.Id == id);
        }
    }
}