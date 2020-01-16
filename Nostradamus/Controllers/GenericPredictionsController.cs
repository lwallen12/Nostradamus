using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nostradamus;
using Nostradamus.Models;

namespace Nostradamus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericPredictionsController : ControllerBase
    {
        private readonly NostradamusContext _context;

        public GenericPredictionsController(NostradamusContext context)
        {
            _context = context;
        }

        // GET: api/GenericPredictions
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public IEnumerable<GenericPrediction> GetGenericPrediction()
        {
            return _context.GenericPrediction;
        }

        // GET: api/GenericPredictions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGenericPrediction([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var genericPrediction = await _context.GenericPrediction.FindAsync(id);

            if (genericPrediction == null)
            {
                return NotFound();
            }

            return Ok(genericPrediction);
        }

        // PUT: api/GenericPredictions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenericPrediction([FromRoute] int id, [FromBody] GenericPrediction genericPrediction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != genericPrediction.Id)
            {
                return BadRequest();
            }

            _context.Entry(genericPrediction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenericPredictionExists(id))
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

        // POST: api/GenericPredictions
        [HttpPost]
        public async Task<IActionResult> PostGenericPrediction([FromBody] GenericPrediction genericPrediction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.GenericPrediction.Add(genericPrediction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGenericPrediction", new { id = genericPrediction.Id }, genericPrediction);
        }

        // DELETE: api/GenericPredictions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenericPrediction([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var genericPrediction = await _context.GenericPrediction.FindAsync(id);
            if (genericPrediction == null)
            {
                return NotFound();
            }

            _context.GenericPrediction.Remove(genericPrediction);
            await _context.SaveChangesAsync();

            return Ok(genericPrediction);
        }

        private bool GenericPredictionExists(int id)
        {
            return _context.GenericPrediction.Any(e => e.Id == id);
        }
    }
}