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
    public class AlunosController : ControllerBase
    {
        private readonly aislan_fitContext _context;

        public AlunosController(aislan_fitContext context)
        {
            _context = context;
        }

        // GET: api/Alunos
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Aluno>>> GetAlunos()
        {
          if (_context.Alunos == null)
          {
              return NotFound();
          }
            return await _context.Alunos.ToListAsync();
        }

        // GET: api/Alunos/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Aluno>> GetAluno(int id)
        {
          if (_context.Alunos == null)
          {
              return NotFound();
          }
            var aluno = await _context.Alunos.FindAsync(id);

            if (aluno == null)
            {
                return NotFound();
            }

            return aluno;
        }

        // PUT: api/Alunos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutAluno(int id, Aluno aluno)
        {
            if (id != aluno.IdAluno)
            {
                return BadRequest();
            }

            _context.Entry(aluno).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlunoExists(id))
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

        // POST: api/Alunos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Aluno>> PostAluno(Aluno aluno)
        {
          if (_context.Alunos == null)
          {
              return Problem("Entity set 'aislan_fitContext.Alunos'  is null.");
          }
            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAluno", new { id = aluno.IdAluno }, aluno);
        }

        // DELETE: api/Alunos/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteAluno(int id)
        {
            if (_context.Alunos == null)
            {
                return NotFound();
            }
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }

            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlunoExists(int id)
        {
            return (_context.Alunos?.Any(e => e.IdAluno == id)).GetValueOrDefault();
        }
    }
}
