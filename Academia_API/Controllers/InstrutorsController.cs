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
    public class InstrutorsController : ControllerBase
    {
        private readonly aislan_fitContext _context;

        public InstrutorsController(aislan_fitContext context)
        {
            _context = context;
        }

        // GET: api/Instrutors
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Instrutor>>> GetInstrutors()
        {
          if (_context.Instrutors == null)
          {
              return NotFound();
          }
            return await _context.Instrutors.ToListAsync();
        }

        // GET: api/Instrutors/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Instrutor>> GetInstrutor(int id)
        {
          if (_context.Instrutors == null)
          {
              return NotFound();
          }
            var instrutor = await _context.Instrutors.FindAsync(id);

            if (instrutor == null)
            {
                return NotFound();
            }

            return instrutor;
        }

        // PUT: api/Instrutors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutInstrutor(int id, Instrutor instrutor)
        {
            if (id != instrutor.IdInstrutor)
            {
                return BadRequest();
            }

            _context.Entry(instrutor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstrutorExists(id))
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

        // POST: api/Instrutors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Instrutor>> PostInstrutor(Instrutor instrutor)
        {
          if (_context.Instrutors == null)
          {
              return Problem("Entity set 'aislan_fitContext.Instrutors'  is null.");
          }
            _context.Instrutors.Add(instrutor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInstrutor", new { id = instrutor.IdInstrutor }, instrutor);
        }

        // DELETE: api/Instrutors/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteInstrutor(int id)
        {
            if (_context.Instrutors == null)
            {
                return NotFound();
            }
            var instrutor = await _context.Instrutors.FindAsync(id);
            if (instrutor == null)
            {
                return NotFound();
            }

            _context.Instrutors.Remove(instrutor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InstrutorExists(int id)
        {
            return (_context.Instrutors?.Any(e => e.IdInstrutor == id)).GetValueOrDefault();
        }
    }
}
