using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EP.APIW.Models;

namespace EP.APIW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversidadsController : ControllerBase
    {
        private readonly evaluaProfeContext _context;

        public UniversidadsController(evaluaProfeContext context)
        {
            _context = context;
        }

        // GET: api/Universidads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Universidad>>> GetUniversidads()
        {
            return await _context.Universidads.ToListAsync();
        }

        // GET: api/Universidads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Universidad>> GetUniversidad(int id)
        {
            var universidad = await _context.Universidads.FindAsync(id);

            if (universidad == null)
            {
                return NotFound();
            }

            return universidad;
        }

        // PUT: api/Universidads/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUniversidad(int id, Universidad universidad)
        {
            if (id != universidad.IdUniversidad)
            {
                return BadRequest();
            }

            _context.Entry(universidad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UniversidadExists(id))
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

        // POST: api/Universidads
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Universidad>> PostUniversidad(Universidad universidad)
        {
            _context.Universidads.Add(universidad);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UniversidadExists(universidad.IdUniversidad))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUniversidad", new { id = universidad.IdUniversidad }, universidad);
        }

        // DELETE: api/Universidads/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Universidad>> DeleteUniversidad(int id)
        {
            var universidad = await _context.Universidads.FindAsync(id);
            if (universidad == null)
            {
                return NotFound();
            }

            _context.Universidads.Remove(universidad);
            await _context.SaveChangesAsync();

            return universidad;
        }

        private bool UniversidadExists(int id)
        {
            return _context.Universidads.Any(e => e.IdUniversidad == id);
        }
    }
}
