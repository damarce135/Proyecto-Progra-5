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
    public class EtiquetaController : ControllerBase
    {
        private readonly SolutionDBContext _context;

        public EtiquetaController(SolutionDBContext context)
        {
            _context = context;
        }

        // GET: api/Etiqueta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<data.Etiqueta>>> GetEtiqueta()
        {
            return new BS.Etiqueta(_context).GetAll().ToList();
        }

        // GET: api/Etiqueta/5
        [HttpGet("{id}")]
        public async Task<ActionResult<data.Etiqueta>> GetEtiqueta(int id)
        {
            var universidad = new BS.Etiqueta(_context).GetOneById(id);

            if (universidad == null)
            {
                return NotFound();
            }

            return universidad;
        }

        // PUT: api/Etiqueta/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEtiqueta(int id, data.Etiqueta universidad)
        {
            if (id != universidad.IdEtiqueta)
            {
                return BadRequest();
            }

            //_context.Entry(universidad).State = EntityState.Modified;

            try
            {
                new BS.Etiqueta(_context).Update(universidad);
            }
            catch (Exception)
            {
                if (!EtiquetaExists(id))
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

        // POST: api/Etiqueta
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<data.Etiqueta>> PostEtiqueta(data.Etiqueta universidad)
        {
            new BS.Etiqueta(_context).Insert(universidad);

            return CreatedAtAction("GetEtiqueta", new { id = universidad.IdEtiqueta }, universidad);
        }

        // DELETE: api/Etiqueta/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<data.Etiqueta>> DeleteEtiqueta(int id)
        {
            var universidad = new BS.Etiqueta(_context).GetOneById(id);
            if (universidad == null)
            {
                return NotFound();
            }

            new BS.Etiqueta(_context).Delete(universidad);

            return universidad;
        }

        private bool EtiquetaExists(int id)
        {
            return (new BS.Etiqueta(_context).GetOneById(id) != null);
        }
    }
}
