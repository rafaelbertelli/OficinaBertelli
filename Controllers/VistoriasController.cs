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
    [Route("api/Vistorias")]
    public class VistoriasController : Controller
    {
        private readonly OficinaBertelliContext _context;

        public VistoriasController(OficinaBertelliContext context)
        {
            _context = context;
        }

        // GET: api/Vistorias
        [HttpGet]
        public IEnumerable<Vistoria> GetVistoria()
        {
            return _context.Vistoria;
        }

        // GET: api/Vistorias/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVistoria([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vistoria = await _context.Vistoria.SingleOrDefaultAsync(m => m.Sequencia == id);

            if (vistoria == null)
            {
                return NotFound();
            }

            return Ok(vistoria);
        }

        // PUT: api/Vistorias/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVistoria([FromRoute] int id, [FromBody] Vistoria vistoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vistoria.Sequencia)
            {
                return BadRequest();
            }

            _context.Entry(vistoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VistoriaExists(id))
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

        // POST: api/Vistorias
        [HttpPost]
        public async Task<IActionResult> PostVistoria([FromBody] Vistoria vistoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Vistoria.Add(vistoria);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VistoriaExists(vistoria.Sequencia))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVistoria", new { id = vistoria.Sequencia }, vistoria);
        }

        // DELETE: api/Vistorias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVistoria([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vistoria = await _context.Vistoria.SingleOrDefaultAsync(m => m.Sequencia == id);
            if (vistoria == null)
            {
                return NotFound();
            }

            _context.Vistoria.Remove(vistoria);
            await _context.SaveChangesAsync();

            return Ok(vistoria);
        }

        private bool VistoriaExists(int id)
        {
            return _context.Vistoria.Any(e => e.Sequencia == id);
        }
    }
}