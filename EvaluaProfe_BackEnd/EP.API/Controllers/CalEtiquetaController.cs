using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public CalEtiquetaController(SolutionDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/CalEtiquetas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.CalEtiqueta>>> GetCalEtiquetas()
        {
            var result = new BS.CalEtiqueta(_context).GetAll().ToList();
            var aux = _mapper.Map<IEnumerable<data.CalEtiqueta>, IEnumerable<Models.CalEtiqueta>>(result);
            return aux.ToList();
        }

        // GET: api/CalEtiquetas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.CalEtiqueta>> GetCalEtiqueta(int id)
        {
            var calEtiqueta = new BS.CalEtiqueta(_context).GetOneById(id);
            var aux = _mapper.Map<data.CalEtiqueta, Models.CalEtiqueta>(calEtiqueta);

            if (aux == null)
            {
                return NotFound();
            }

            return aux;
        }

        // PUT: api/CalEtiquetas/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalEtiqueta(int id, Models.CalEtiqueta calEtiqueta)
        {
            if (id != calEtiqueta.IdCalEtiqueta)
            {
                return BadRequest();
            }

            try
            {
                var aux = _mapper.Map<Models.CalEtiqueta, data.CalEtiqueta>(calEtiqueta);
                new BS.CalEtiqueta(_context).Update(aux);
            }
            catch (Exception ee)
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

        // POST: api/CalEtiquetas
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Models.CalEtiqueta>> PostCalEtiqueta(Models.CalEtiqueta calEtiqueta)
        {
            var aux = _mapper.Map<Models.CalEtiqueta, data.CalEtiqueta>(calEtiqueta);
            new BS.CalEtiqueta(_context).Insert(aux);

            return CreatedAtAction("GetCalEtiqueta", new { id = calEtiqueta.IdCalEtiqueta }, calEtiqueta);
        }

        // DELETE: api/CalEtiquetas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.CalEtiqueta>> DeleteCalEtiqueta(int id)
        {
            var calEtiqueta = new BS.CalEtiqueta(_context).GetOneById(id);
            var aux = _mapper.Map<data.CalEtiqueta, Models.CalEtiqueta>(calEtiqueta);
            if (calEtiqueta == null)
            {
                return NotFound();
            }

            new BS.CalEtiqueta(_context).Delete(calEtiqueta);

            return aux;
        }

        private bool CalEtiquetaExists(int id)
        {
            return (new BS.CalEtiqueta(_context).GetOneById(id) != null);
        }
    }
}
