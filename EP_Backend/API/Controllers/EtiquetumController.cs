using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DAL.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using data = DO.Objects; 

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EtiquetumController : ControllerBase
    {
        private readonly SolutionDBContext _context;
        private readonly IMapper _mapper;

        public EtiquetumController(SolutionDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Etiquetums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Etiquetum>>> GetEtiquetums()
        {
            var result = new BS.Etiqueta(_context).GetAll().ToList();
            var aux = _mapper.Map<IEnumerable<data.Etiquetum>, IEnumerable<Models.Etiquetum>>(result);
            return aux.ToList();
        }

        // GET: api/Etiquetums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Etiquetum>> GetEtiquetum(int id)
        {
            var etiquetum = new BS.Etiqueta(_context).GetOneById(id);
            var aux = _mapper.Map<data.Etiquetum, Models.Etiquetum>(etiquetum);

            if (aux == null)
            {
                return NotFound();
            }

            return aux;
        }

        // PUT: api/Etiquetums/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEtiquetum(int id, Models.Etiquetum etiquetum)
        {
            if (id != etiquetum.IdEtiqueta)
            {
                return BadRequest();
            }

            try
            {
                var aux = _mapper.Map<Models.Etiquetum, data.Etiquetum>(etiquetum);
                new BS.Etiqueta(_context).Update(aux);
            }
            catch (Exception ee)
            {
                if (!EtiquetumExists(id))
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

        // POST: api/Etiquetums
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Models.Etiquetum>> PostEtiquetum(Models.Etiquetum etiquetum)
        {
            var aux = _mapper.Map<Models.Etiquetum, data.Etiquetum>(etiquetum);
            new BS.Etiqueta(_context).Insert(aux);

            return CreatedAtAction("GetEtiquetum", new { id = etiquetum.IdEtiqueta }, etiquetum);
        }

        // DELETE: api/Etiquetums/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.Etiquetum>> DeleteEtiquetum(int id)
        {
            var etiquetum = new BS.Etiqueta(_context).GetOneById(id);
            var aux = _mapper.Map<data.Etiquetum, Models.Etiquetum>(etiquetum);
            if (etiquetum == null)
            {
                return NotFound();
            }

            new BS.Etiqueta(_context).Delete(etiquetum);

            return aux;
        }

        private bool EtiquetumExists(int id)
        {
            return (new BS.Etiqueta(_context).GetOneById(id) != null);
        }
    }
}
