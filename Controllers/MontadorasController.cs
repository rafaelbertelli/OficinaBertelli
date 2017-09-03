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
    [Route("api/Montadoras")]
    public class MontadorasController : Controller
    {
        private readonly OficinaBertelliContext _context;

        public MontadorasController(OficinaBertelliContext context)
        {
            _context = context;
        }

        // GET: api/Montadoras
        [HttpGet]
        public IEnumerable<Montadoras> GetMontadoras()
        {
            return _context.Montadoras;
        }

        // GET: api/Montadoras/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMontadoras([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var montadoras = await _context.Montadoras.SingleOrDefaultAsync(m => m.Codigo == id);

            if (montadoras == null)
            {
                return NotFound();
            }

            return Ok(montadoras);
        }

        // PUT: api/Montadoras/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMontadoras([FromRoute] int id, [FromBody] Montadoras montadoras)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != montadoras.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(montadoras).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MontadorasExists(id))
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

        // POST: api/Montadoras
        [HttpPost]
        public async Task<IActionResult> PostMontadoras([FromBody] Montadoras montadoras)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Montadoras.Add(montadoras);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MontadorasExists(montadoras.Codigo))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMontadoras", new { id = montadoras.Codigo }, montadoras);
        }

        // DELETE: api/Montadoras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMontadoras([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var montadoras = await _context.Montadoras.SingleOrDefaultAsync(m => m.Codigo == id);
            if (montadoras == null)
            {
                return NotFound();
            }

            _context.Montadoras.Remove(montadoras);
            await _context.SaveChangesAsync();

            return Ok(montadoras);
        }

        private bool MontadorasExists(int id)
        {
            return _context.Montadoras.Any(e => e.Codigo == id);
        }
    }
}