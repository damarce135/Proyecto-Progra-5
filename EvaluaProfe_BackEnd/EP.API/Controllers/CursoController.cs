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
    public class CursoController : ControllerBase
    {
        private readonly SolutionDBContext _context;

        public CursoController(SolutionDBContext context)
        {
            _context = context;
        }

        // GET: api/Curso
        [HttpGet]
        public async Task<ActionResult<IEnumerable<data.Curso>>> GetCurso()
        {
            return new BS.Curso(_context).GetAll().ToList();
        }

        // GET: api/Curso/5
        [HttpGet("{id}")]
        public async Task<ActionResult<data.Curso>> GetCurso(int id)
        {
            var universidad = new BS.Curso(_context).GetOneById(id);

            if (universidad == null)
            {
                return NotFound();
            }

            return universidad;
        }

        // PUT: api/Curso/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurso(int id, data.Curso universidad)
        {
            if (id != universidad.IdCurso)
            {
                return BadRequest();
            }

            //_context.Entry(universidad).State = EntityState.Modified;

            try
            {
                new BS.Curso(_context).Update(universidad);
            }
            catch (Exception)
            {
                if (!CursoExists(id))
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

        // POST: api/Curso
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<data.Curso>> PostCurso(data.Curso universidad)
        {
            new BS.Curso(_context).Insert(universidad);

            return CreatedAtAction("GetCurso", new { id = universidad.IdCurso }, universidad);
        }

        // DELETE: api/Curso/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<data.Curso>> DeleteCurso(int id)
        {
            var universidad = new BS.Curso(_context).GetOneById(id);
            if (universidad == null)
            {
                return NotFound();
            }

            new BS.Curso(_context).Delete(universidad);

            return universidad;
        }

        private bool CursoExists(int id)
        {
            return (new BS.Curso(_context).GetOneById(id) != null);
        }
    }
}
