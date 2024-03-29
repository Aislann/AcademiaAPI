﻿using System;
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
    public class AulasController : ControllerBase
    {
        private readonly aislan_fitContext _context;

        public AulasController(aislan_fitContext context)
        {
            _context = context;
        }

        // GET: api/Aulas
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Aula>>> GetAulas()
        {
          if (_context.Aulas == null)
          {
              return NotFound();
          }
            return await _context.Aulas.ToListAsync();
        }

        // GET: api/Aulas/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Aula>> GetAula(int id)
        {
          if (_context.Aulas == null)
          {
              return NotFound();
          }
            var aula = await _context.Aulas.FindAsync(id);

            if (aula == null)
            {
                return NotFound();
            }

            return aula;
        }

        // PUT: api/Aulas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutAula(int id, Aula aula)
        {
            if (id != aula.IdAula)
            {
                return BadRequest();
            }

            _context.Entry(aula).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AulaExists(id))
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

        // POST: api/Aulas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Aula>> PostAula(Aula aula)
        {
          if (_context.Aulas == null)
          {
              return Problem("Entity set 'aislan_fitContext.Aulas'  is null.");
          }
            _context.Aulas.Add(aula);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAula", new { id = aula.IdAula }, aula);
        }

        // DELETE: api/Aulas/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteAula(int id)
        {
            if (_context.Aulas == null)
            {
                return NotFound();
            }
            var aula = await _context.Aulas.FindAsync(id);
            if (aula == null)
            {
                return NotFound();
            }

            _context.Aulas.Remove(aula);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AulaExists(int id)
        {
            return (_context.Aulas?.Any(e => e.IdAula == id)).GetValueOrDefault();
        }
    }
}
