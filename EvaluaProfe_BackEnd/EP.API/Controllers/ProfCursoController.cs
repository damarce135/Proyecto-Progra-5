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
    public class ProfCursoController : ControllerBase
    {
        private readonly SolutionDBContext _context;
        private readonly IMapper _mapper;

        public ProfCursoController(SolutionDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/ProfCursos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.ProfCurso>>> GetProfCursos()
        {
            var result = new BS.ProfCurso(_context).GetAll().ToList();
            var aux = _mapper.Map<IEnumerable<data.ProfCurso>, IEnumerable<Models.ProfCurso>>(result);
            return aux.ToList();
        }

        // GET: api/ProfCursos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.ProfCurso>> GetProfCurso(int id)
        {
            var profCurso = new BS.ProfCurso(_context).GetOneById(id);
            var aux = _mapper.Map<data.ProfCurso, Models.ProfCurso>(profCurso);

            if (aux == null)
            {
                return NotFound();
            }

            return aux;
        }

        // PUT: api/ProfCursos/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfCurso(int id, Models.ProfCurso profCurso)
        {
            if (id != profCurso.IdProfCurso)
            {
                return BadRequest();
            }

            try
            {
                var aux = _mapper.Map<Models.ProfCurso, data.ProfCurso>(profCurso);
                new BS.ProfCurso(_context).Update(aux);
            }
            catch (Exception ee)
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

        // POST: api/ProfCursos
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Models.ProfCurso>> PostProfCurso(Models.ProfCurso profCurso)
        {
            var aux = _mapper.Map<Models.ProfCurso, data.ProfCurso>(profCurso);
            new BS.ProfCurso(_context).Insert(aux);

            return CreatedAtAction("GetProfCurso", new { id = profCurso.IdProfCurso }, profCurso);
        }

        // DELETE: api/ProfCursos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.ProfCurso>> DeleteProfCurso(int id)
        {
            var profCurso = new BS.ProfCurso(_context).GetOneById(id);
            var aux = _mapper.Map<data.ProfCurso, Models.ProfCurso>(profCurso);
            if (profCurso == null)
            {
                return NotFound();
            }

            new BS.ProfCurso(_context).Delete(profCurso);

            return aux;
        }

        private bool ProfCursoExists(int id)
        {
            return (new BS.ProfCurso(_context).GetOneById(id) != null);
        }
    }
}
