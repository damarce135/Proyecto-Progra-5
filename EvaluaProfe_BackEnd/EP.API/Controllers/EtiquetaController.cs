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
    public class EtiquetaController : ControllerBase
    {
        private readonly SolutionDBContext _context;
        private readonly IMapper _mapper;

        public EtiquetaController(SolutionDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Etiquetas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Etiqueta>>> GetEtiquetas()
        {
            var result = new BS.Etiqueta(_context).GetAll().ToList();
            var aux = _mapper.Map<IEnumerable<data.Etiqueta>, IEnumerable<Models.Etiqueta>>(result);
            return aux.ToList();
        }

        // GET: api/Etiquetas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Etiqueta>> GetEtiqueta(int id)
        {
            var etiqueta = new BS.Etiqueta(_context).GetOneById(id);
            var aux = _mapper.Map<data.Etiqueta, Models.Etiqueta>(etiqueta);

            if (aux == null)
            {
                return NotFound();
            }

            return aux;
        }

        // PUT: api/Etiquetas/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEtiqueta(int id, Models.Etiqueta etiqueta)
        {
            if (id != etiqueta.IdEtiqueta)
            {
                return BadRequest();
            }

            try
            {
                var aux = _mapper.Map<Models.Etiqueta, data.Etiqueta>(etiqueta);
                new BS.Etiqueta(_context).Update(aux);
            }
            catch (Exception ee)
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

        // POST: api/Etiquetas
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Models.Etiqueta>> PostEtiqueta(Models.Etiqueta etiqueta)
        {
            var aux = _mapper.Map<Models.Etiqueta, data.Etiqueta>(etiqueta);
            new BS.Etiqueta(_context).Insert(aux);

            return CreatedAtAction("GetEtiqueta", new { id = etiqueta.IdEtiqueta }, etiqueta);
        }

        // DELETE: api/Etiquetas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.Etiqueta>> DeleteEtiqueta(int id)
        {
            var etiqueta = new BS.Etiqueta(_context).GetOneById(id);
            var aux = _mapper.Map<data.Etiqueta, Models.Etiqueta>(etiqueta);
            if (etiqueta == null)
            {
                return NotFound();
            }

            new BS.Etiqueta(_context).Delete(etiqueta);

            return aux;
        }

        private bool EtiquetaExists(int id)
        {
            return (new BS.Etiqueta(_context).GetOneById(id) != null);
        }
    }
}
