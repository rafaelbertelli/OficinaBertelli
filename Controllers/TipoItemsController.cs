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
    [Route("api/TipoItems")]
    public class TipoItemsController : Controller
    {
        private readonly OficinaBertelliContext _context;

        public TipoItemsController(OficinaBertelliContext context)
        {
            _context = context;
        }

        // GET: api/TipoItems
        [HttpGet]
        public IEnumerable<TipoItem> GetTipoItem()
        {
            return _context.TipoItem;
        }

        // GET: api/TipoItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTipoItem([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tipoItem = await _context.TipoItem.SingleOrDefaultAsync(m => m.Tipo == id);

            if (tipoItem == null)
            {
                return NotFound();
            }

            return Ok(tipoItem);
        }

        // PUT: api/TipoItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoItem([FromRoute] string id, [FromBody] TipoItem tipoItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoItem.Tipo)
            {
                return BadRequest();
            }

            _context.Entry(tipoItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoItemExists(id))
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

        // POST: api/TipoItems
        [HttpPost]
        public async Task<IActionResult> PostTipoItem([FromBody] TipoItem tipoItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TipoItem.Add(tipoItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoItem", new { id = tipoItem.Tipo }, tipoItem);
        }

        // DELETE: api/TipoItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoItem([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tipoItem = await _context.TipoItem.SingleOrDefaultAsync(m => m.Tipo == id);
            if (tipoItem == null)
            {
                return NotFound();
            }

            _context.TipoItem.Remove(tipoItem);
            await _context.SaveChangesAsync();

            return Ok(tipoItem);
        }

        private bool TipoItemExists(string id)
        {
            return _context.TipoItem.Any(e => e.Tipo == id);
        }
    }
}