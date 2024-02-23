using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Academia_API.Models;
using Microsoft.AspNetCore.Authorization;

namespace Academia_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresencasController : ControllerBase
    {
        private readonly aislan_fitContext _context;

        public PresencasController(aislan_fitContext context)
        {
            _context = context;
        }

        // GET: api/Presencas
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Presenca>>> GetPresencas()
        {
          if (_context.Presencas == null)
          {
              return NotFound();
          }
            return await _context.Presencas.ToListAsync();
        }

        // GET: api/Presencas/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Presenca>> GetPresenca(int id)
        {
          if (_context.Presencas == null)
          {
              return NotFound();
          }
            var presenca = await _context.Presencas.FindAsync(id);

            if (presenca == null)
            {
                return NotFound();
            }

            return presenca;
        }

        // PUT: api/Presencas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutPresenca(int id, Presenca presenca)
        {
            if (id != presenca.IdPresenca)
            {
                return BadRequest();
            }

            _context.Entry(presenca).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PresencaExists(id))
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

        // POST: api/Presencas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Presenca>> PostPresenca(Presenca presenca)
        {
          if (_context.Presencas == null)
          {
              return Problem("Entity set 'aislan_fitContext.Presencas'  is null.");
          }
            _context.Presencas.Add(presenca);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPresenca", new { id = presenca.IdPresenca }, presenca);
        }

        // DELETE: api/Presencas/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeletePresenca(int id)
        {
            if (_context.Presencas == null)
            {
                return NotFound();
            }
            var presenca = await _context.Presencas.FindAsync(id);
            if (presenca == null)
            {
                return NotFound();
            }

            _context.Presencas.Remove(presenca);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PresencaExists(int id)
        {
            return (_context.Presencas?.Any(e => e.IdPresenca == id)).GetValueOrDefault();
        }
    }
}
