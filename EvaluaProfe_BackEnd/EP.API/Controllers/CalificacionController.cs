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
    public class CalificacionController : ControllerBase
    {
        private readonly SolutionDBContext _context;

        public CalificacionController(SolutionDBContext context)
        {
            _context = context;
        }

        // GET: api/Calificacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<data.Calificacion>>> GetCalificacion()
        {
            return new BS.Calificacion(_context).GetAll().ToList();
        }

        // GET: api/Calificacion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<data.Calificacion>> GetCalificacion(int id)
        {
            var universidad = new BS.Calificacion(_context).GetOneById(id);

            if (universidad == null)
            {
                return NotFound();
            }

            return universidad;
        }

        // PUT: api/Calificacion/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalificacion(int id, data.Calificacion universidad)
        {
            if (id != universidad.IdCalificacion)
            {
                return BadRequest();
            }

            //_context.Entry(universidad).State = EntityState.Modified;

            try
            {
                new BS.Calificacion(_context).Update(universidad);
            }
            catch (Exception)
            {
                if (!CalificacionExists(id))
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

        // POST: api/Calificacion
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<data.Calificacion>> PostCalificacion(data.Calificacion universidad)
        {
            new BS.Calificacion(_context).Insert(universidad);

            return CreatedAtAction("GetCalificacion", new { id = universidad.IdCalificacion }, universidad);
        }

        // DELETE: api/Calificacion/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<data.Calificacion>> DeleteCalificacion(int id)
        {
            var universidad = new BS.Calificacion(_context).GetOneById(id);
            if (universidad == null)
            {
                return NotFound();
            }

            new BS.Calificacion(_context).Delete(universidad);

            return universidad;
        }

        private bool CalificacionExists(int id)
        {
            return (new BS.Calificacion(_context).GetOneById(id) != null);
        }
    }
}
