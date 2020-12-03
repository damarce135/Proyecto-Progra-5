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
    public class CarreraController : ControllerBase
    {
        private readonly SolutionDBContext _context;

        public CarreraController(SolutionDBContext context)
        {
            _context = context;
        }

        // GET: api/Carrera
        [HttpGet]
        public async Task<ActionResult<IEnumerable<data.Carrera>>> GetCarrera()
        {
            return new BS.Carrera(_context).GetAll().ToList();
        }

        // GET: api/Carrera/5
        [HttpGet("{id}")]
        public async Task<ActionResult<data.Carrera>> GetCarrera(int id)
        {
            var universidad = new BS.Carrera(_context).GetOneById(id);

            if (universidad == null)
            {
                return NotFound();
            }

            return universidad;
        }

        // PUT: api/Carrera/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarrera(int id, data.Carrera universidad)
        {
            if (id != universidad.IdCarrera)
            {
                return BadRequest();
            }

            //_context.Entry(universidad).State = EntityState.Modified;

            try
            {
                new BS.Carrera(_context).Update(universidad);
            }
            catch (Exception)
            {
                if (!CarreraExists(id))
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

        // POST: api/Carrera
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<data.Carrera>> PostCarrera(data.Carrera universidad)
        {
            new BS.Carrera(_context).Insert(universidad);

            return CreatedAtAction("GetCarrera", new { id = universidad.IdCarrera }, universidad);
        }

        // DELETE: api/Carrera/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<data.Carrera>> DeleteCarrera(int id)
        {
            var universidad = new BS.Carrera(_context).GetOneById(id);
            if (universidad == null)
            {
                return NotFound();
            }

            new BS.Carrera(_context).Delete(universidad);

            return universidad;
        }

        private bool CarreraExists(int id)
        {
            return (new BS.Carrera(_context).GetOneById(id) != null);
        }
    }
}
