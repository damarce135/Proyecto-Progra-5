using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EP.DAL.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using data = EP.DO.Objects;

namespace EP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoCarreraController : ControllerBase
    {
        private readonly SolutionDBContext _context;

        public CursoCarreraController(SolutionDBContext context)
        {
            _context = context;
        }

        // GET: api/CursoCarrera
        [HttpGet]
        public async Task<ActionResult<IEnumerable<data.CursoCarrera>>> GetCursoCarrera()
        {
            return new BS.CursoCarrera(_context).GetAll().ToList();
        }

        // GET: api/CursoCarrera/5
        [HttpGet("{id}")]
        public async Task<ActionResult<data.CursoCarrera>> GetCursoCarrera(int id)
        {
            var universidad = new BS.CursoCarrera(_context).GetOneById(id);

            if (universidad == null)
            {
                return NotFound();
            }

            return universidad;
        }

        // PUT: api/CursoCarrera/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCursoCarrera(int id, data.CursoCarrera universidad)
        {
            if (id != universidad.IdCursoCarrera)
            {
                return BadRequest();
            }

            //_context.Entry(universidad).State = EntityState.Modified;

            try
            {
                new BS.CursoCarrera(_context).Update(universidad);
            }
            catch (Exception)
            {
                if (!CursoCarreraExists(id))
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

        // POST: api/CursoCarrera
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<data.CursoCarrera>> PostCursoCarrera(data.CursoCarrera universidad)
        {
            new BS.CursoCarrera(_context).Insert(universidad);

            return CreatedAtAction("GetCursoCarrera", new { id = universidad.IdCursoCarrera }, universidad);
        }

        // DELETE: api/CursoCarrera/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<data.CursoCarrera>> DeleteCursoCarrera(int id)
        {
            var universidad = new BS.CursoCarrera(_context).GetOneById(id);
            if (universidad == null)
            {
                return NotFound();
            }

            new BS.CursoCarrera(_context).Delete(universidad);

            return universidad;
        }

        private bool CursoCarreraExists(int id)
        {
            return (new BS.CursoCarrera(_context).GetOneById(id) != null);
        }
    }
}
