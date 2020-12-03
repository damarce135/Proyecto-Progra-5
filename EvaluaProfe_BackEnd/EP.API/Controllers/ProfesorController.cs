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
    public class ProfesorController : ControllerBase
    {
        private readonly SolutionDBContext _context;

        public ProfesorController(SolutionDBContext context)
        {
            _context = context;
        }

        // GET: api/Profesor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<data.Profesor>>> GetProfesor()
        {
            return new BS.Profesor(_context).GetAll().ToList();
        }

        // GET: api/Profesor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<data.Profesor>> GetProfesor(int id)
        {
            var universidad = new BS.Profesor(_context).GetOneById(id);

            if (universidad == null)
            {
                return NotFound();
            }

            return universidad;
        }

        // PUT: api/Profesor/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfesor(int id, data.Profesor universidad)
        {
            if (id != universidad.IdProfesor)
            {
                return BadRequest();
            }

            //_context.Entry(universidad).State = EntityState.Modified;

            try
            {
                new BS.Profesor(_context).Update(universidad);
            }
            catch (Exception)
            {
                if (!ProfesorExists(id))
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

        // POST: api/Profesor
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<data.Profesor>> PostProfesor(data.Profesor universidad)
        {
            new BS.Profesor(_context).Insert(universidad);

            return CreatedAtAction("GetProfesor", new { id = universidad.IdProfesor }, universidad);
        }

        // DELETE: api/Profesor/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<data.Profesor>> DeleteProfesor(int id)
        {
            var universidad = new BS.Profesor(_context).GetOneById(id);
            if (universidad == null)
            {
                return NotFound();
            }

            new BS.Profesor(_context).Delete(universidad);

            return universidad;
        }

        private bool ProfesorExists(int id)
        {
            return (new BS.Profesor(_context).GetOneById(id) != null);
        }
    }
}
