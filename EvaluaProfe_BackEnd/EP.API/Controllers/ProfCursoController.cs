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
    public class ProfCursoController : ControllerBase
    {
        private readonly SolutionDBContext _context;

        public ProfCursoController(SolutionDBContext context)
        {
            _context = context;
        }

        // GET: api/ProfCurso
        [HttpGet]
        public async Task<ActionResult<IEnumerable<data.ProfCurso>>> GetProfCurso()
        {
            return new BS.ProfCurso(_context).GetAll().ToList();
        }

        // GET: api/ProfCurso/5
        [HttpGet("{id}")]
        public async Task<ActionResult<data.ProfCurso>> GetProfCurso(int id)
        {
            var universidad = new BS.ProfCurso(_context).GetOneById(id);

            if (universidad == null)
            {
                return NotFound();
            }

            return universidad;
        }

        // PUT: api/ProfCurso/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfCurso(int id, data.ProfCurso universidad)
        {
            if (id != universidad.IdProfCurso)
            {
                return BadRequest();
            }

            //_context.Entry(universidad).State = EntityState.Modified;

            try
            {
                new BS.ProfCurso(_context).Update(universidad);
            }
            catch (Exception)
            {
                if (!ProfCursoExists(id))
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

        // POST: api/ProfCurso
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<data.ProfCurso>> PostProfCurso(data.ProfCurso universidad)
        {
            new BS.ProfCurso(_context).Insert(universidad);

            return CreatedAtAction("GetProfCurso", new { id = universidad.IdProfCurso }, universidad);
        }

        // DELETE: api/ProfCurso/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<data.ProfCurso>> DeleteProfCurso(int id)
        {
            var universidad = new BS.ProfCurso(_context).GetOneById(id);
            if (universidad == null)
            {
                return NotFound();
            }

            new BS.ProfCurso(_context).Delete(universidad);

            return universidad;
        }

        private bool ProfCursoExists(int id)
        {
            return (new BS.ProfCurso(_context).GetOneById(id) != null);
        }
    }
}
