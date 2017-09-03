using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OficinaBertelli.Models;

namespace OficinaBertelli.Controllers
{
    [Produces("application/json")]
    [Route("api/HistItems")]
    public class HistItemsController : Controller
    {
        private readonly OficinaBertelliContext _context;

        public HistItemsController(OficinaBertelliContext context)
        {
            _context = context;
        }

        // GET: api/HistItems
        [HttpGet]
        public IEnumerable<HistItem> GetHistItem()
        {
            return _context.HistItem;
        }

        // GET: api/HistItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHistItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var histItem = await _context.HistItem.SingleOrDefaultAsync(m => m.IdHitem == id);

            if (histItem == null)
            {
                return NotFound();
            }

            return Ok(histItem);
        }

        // PUT: api/HistItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistItem([FromRoute] int id, [FromBody] HistItem histItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != histItem.IdHitem)
            {
                return BadRequest();
            }

            _context.Entry(histItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistItemExists(id))
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

        // POST: api/HistItems
        [HttpPost]
        public async Task<IActionResult> PostHistItem([FromBody] HistItem histItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.HistItem.Add(histItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHistItem", new { id = histItem.IdHitem }, histItem);
        }

        // DELETE: api/HistItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var histItem = await _context.HistItem.SingleOrDefaultAsync(m => m.IdHitem == id);
            if (histItem == null)
            {
                return NotFound();
            }

            _context.HistItem.Remove(histItem);
            await _context.SaveChangesAsync();

            return Ok(histItem);
        }

        private bool HistItemExists(int id)
        {
            return _context.HistItem.Any(e => e.IdHitem == id);
        }
    }
}