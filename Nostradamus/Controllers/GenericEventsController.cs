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
    public class GenericEventsController : ControllerBase
    {
        private readonly NostradamusContext _context;

        public GenericEventsController(NostradamusContext context)
        {
            _context = context;
        }

        // GET: api/GenericEvents
        [HttpGet]
        public IEnumerable<GenericEvent> GetGenericEvent()
        {
            return _context.GenericEvent;
        }

        // GET: api/GenericEvents/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGenericEvent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var genericEvent = await _context.GenericEvent.FindAsync(id);

            if (genericEvent == null)
            {
                return NotFound();
            }

            return Ok(genericEvent);
        }

        // PUT: api/GenericEvents/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenericEvent([FromRoute] int id, [FromBody] GenericEvent genericEvent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != genericEvent.Id)
            {
                return BadRequest();
            }

            _context.Entry(genericEvent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenericEventExists(id))
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

        // POST: api/GenericEvents
        [HttpPost]
        public async Task<IActionResult> PostGenericEvent([FromBody] GenericEvent genericEvent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.GenericEvent.Add(genericEvent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGenericEvent", new { id = genericEvent.Id }, genericEvent);
        }

        // DELETE: api/GenericEvents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenericEvent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var genericEvent = await _context.GenericEvent.FindAsync(id);
            if (genericEvent == null)
            {
                return NotFound();
            }

            _context.GenericEvent.Remove(genericEvent);
            await _context.SaveChangesAsync();

            return Ok(genericEvent);
        }

        private bool GenericEventExists(int id)
        {
            return _context.GenericEvent.Any(e => e.Id == id);
        }
    }
}