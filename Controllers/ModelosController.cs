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
    [Route("api/Modelos")]
    public class ModelosController : Controller
    {
        private readonly OficinaBertelliContext _context;

        public ModelosController(OficinaBertelliContext context)
        {
            _context = context;
        }

        // GET: api/Modelos
        [HttpGet]
        public IEnumerable<Modelos> GetModelos()
        {
            return _context.Modelos;
        }

        // GET: api/Modelos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetModelos([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var modelos = await _context.Modelos.SingleOrDefaultAsync(m => m.Codigo == id);

            if (modelos == null)
            {
                return NotFound();
            }

            return Ok(modelos);
        }

        // PUT: api/Modelos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModelos([FromRoute] int id, [FromBody] Modelos modelos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != modelos.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(modelos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModelosExists(id))
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

        // POST: api/Modelos
        [HttpPost]
        public async Task<IActionResult> PostModelos([FromBody] Modelos modelos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Modelos.Add(modelos);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ModelosExists(modelos.Codigo))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetModelos", new { id = modelos.Codigo }, modelos);
        }

        // DELETE: api/Modelos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModelos([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var modelos = await _context.Modelos.SingleOrDefaultAsync(m => m.Codigo == id);
            if (modelos == null)
            {
                return NotFound();
            }

            _context.Modelos.Remove(modelos);
            await _context.SaveChangesAsync();

            return Ok(modelos);
        }

        private bool ModelosExists(int id)
        {
            return _context.Modelos.Any(e => e.Codigo == id);
        }
    }
}