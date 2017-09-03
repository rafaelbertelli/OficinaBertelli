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
    [Route("api/Historicos")]
    public class HistoricosController : Controller
    {
        private readonly OficinaBertelliContext _context;

        public HistoricosController(OficinaBertelliContext context)
        {
            _context = context;
        }

        // GET: api/Historicos
        [HttpGet]
        public IEnumerable<Historico> GetHistorico()
        {
            return _context.Historico;
        }

        // GET: api/Historicos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHistorico([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var historico = await _context.Historico.SingleOrDefaultAsync(m => m.OrdemServico == id);

            if (historico == null)
            {
                return NotFound();
            }

            return Ok(historico);
        }

        // PUT: api/Historicos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistorico([FromRoute] int id, [FromBody] Historico historico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != historico.OrdemServico)
            {
                return BadRequest();
            }

            _context.Entry(historico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistoricoExists(id))
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

        // POST: api/Historicos
        [HttpPost]
        public async Task<IActionResult> PostHistorico([FromBody] Historico historico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Historico.Add(historico);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HistoricoExists(historico.OrdemServico))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHistorico", new { id = historico.OrdemServico }, historico);
        }

        // DELETE: api/Historicos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistorico([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var historico = await _context.Historico.SingleOrDefaultAsync(m => m.OrdemServico == id);
            if (historico == null)
            {
                return NotFound();
            }

            _context.Historico.Remove(historico);
            await _context.SaveChangesAsync();

            return Ok(historico);
        }

        private bool HistoricoExists(int id)
        {
            return _context.Historico.Any(e => e.OrdemServico == id);
        }
    }
}