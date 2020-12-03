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
    public class CalEtiquetaController : ControllerBase
    {
        private readonly SolutionDBContext _context;

        public CalEtiquetaController(SolutionDBContext context)
        {
            _context = context;
        }

        // GET: api/CalEtiqueta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<data.CalEtiqueta>>> GetCalEtiqueta()
        {
            return new BS.CalEtiqueta(_context).GetAll().ToList();
        }

        // GET: api/CalEtiqueta/5
        [HttpGet("{id}")]
        public async Task<ActionResult<data.CalEtiqueta>> GetCalEtiqueta(int id)
        {
            var universidad = new BS.CalEtiqueta(_context).GetOneById(id);

            if (universidad == null)
            {
                return NotFound();
            }

            return universidad;
        }

        // PUT: api/CalEtiqueta/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalEtiqueta(int id, data.CalEtiqueta universidad)
        {
            if (id != universidad.IdCalEtiqueta)
            {
                return BadRequest();
            }

            //_context.Entry(universidad).State = EntityState.Modified;

            try
            {
                new BS.CalEtiqueta(_context).Update(universidad);
            }
            catch (Exception)
            {
                if (!CalEtiquetaExists(id))
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

        // POST: api/CalEtiqueta
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<data.CalEtiqueta>> PostCalEtiqueta(data.CalEtiqueta universidad)
        {
            new BS.CalEtiqueta(_context).Insert(universidad);

            return CreatedAtAction("GetCalEtiqueta", new { id = universidad.IdCalEtiqueta }, universidad);
        }

        // DELETE: api/CalEtiqueta/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<data.CalEtiqueta>> DeleteCalEtiqueta(int id)
        {
            var universidad = new BS.CalEtiqueta(_context).GetOneById(id);
            if (universidad == null)
            {
                return NotFound();
            }

            new BS.CalEtiqueta(_context).Delete(universidad);

            return universidad;
        }

        private bool CalEtiquetaExists(int id)
        {
            return (new BS.CalEtiqueta(_context).GetOneById(id) != null);
        }
    }
}
