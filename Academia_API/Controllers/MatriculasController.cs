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
    public class MatriculasController : ControllerBase
    {
        private readonly aislan_fitContext _context;

        public MatriculasController(aislan_fitContext context)
        {
            _context = context;
        }

        // GET: api/Matriculas
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Matricula>>> GetMatriculas()
        {
          if (_context.Matriculas == null)
          {
              return NotFound();
          }
            return await _context.Matriculas.ToListAsync();
        }

        // GET: api/Matriculas/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Matricula>> GetMatricula(int id)
        {
          if (_context.Matriculas == null)
          {
              return NotFound();
          }
            var matricula = await _context.Matriculas.FindAsync(id);

            if (matricula == null)
            {
                return NotFound();
            }

            return matricula;
        }

        // PUT: api/Matriculas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutMatricula(int id, Matricula matricula)
        {
            if (id != matricula.IdMatricula)
            {
                return BadRequest();
            }

            _context.Entry(matricula).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatriculaExists(id))
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

        // POST: api/Matriculas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Matricula>> PostMatricula(Matricula matricula)
        {
          if (_context.Matriculas == null)
          {
              return Problem("Entity set 'aislan_fitContext.Matriculas'  is null.");
          }
            _context.Matriculas.Add(matricula);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMatricula", new { id = matricula.IdMatricula }, matricula);
        }

        // DELETE: api/Matriculas/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteMatricula(int id)
        {
            if (_context.Matriculas == null)
            {
                return NotFound();
            }
            var matricula = await _context.Matriculas.FindAsync(id);
            if (matricula == null)
            {
                return NotFound();
            }

            _context.Matriculas.Remove(matricula);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MatriculaExists(int id)
        {
            return (_context.Matriculas?.Any(e => e.IdMatricula == id)).GetValueOrDefault();
        }
    }
}
