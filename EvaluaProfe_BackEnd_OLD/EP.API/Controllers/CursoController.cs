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
    public class CursoController : ControllerBase
    {
        private readonly SolutionDBContext _context;
        private readonly IMapper _mapper;

        public CursoController(SolutionDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Cursos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Curso>>> GetCursos()
        {
            var result = new BS.Curso(_context).GetAll().ToList();
            var aux = _mapper.Map<IEnumerable<data.Curso>, IEnumerable<Models.Curso>>(result);
            return aux.ToList();
        }

        // GET: api/Cursos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Curso>> GetCurso(int id)
        {
            var curso = new BS.Curso(_context).GetOneById(id);
            var aux = _mapper.Map<data.Curso, Models.Curso>(curso);

            if (aux == null)
            {
                return NotFound();
            }

            return aux;
        }

        // PUT: api/Cursos/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurso(int id, Models.Curso curso)
        {
            if (id != curso.IdCurso)
            {
                return BadRequest();
            }

            try
            {
                var aux = _mapper.Map<Models.Curso, data.Curso>(curso);
                new BS.Curso(_context).Update(aux);
            }
            catch (Exception ee)
            {
                if (!CursoExists(id))
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

        // POST: api/Cursos
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Models.Curso>> PostCurso(Models.Curso curso)
        {
            var aux = _mapper.Map<Models.Curso, data.Curso>(curso);
            new BS.Curso(_context).Insert(aux);

            return CreatedAtAction("GetCurso", new { id = curso.IdCurso }, curso);
        }

        // DELETE: api/Cursos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.Curso>> DeleteCurso(int id)
        {
            var curso = new BS.Curso(_context).GetOneById(id);
            var aux = _mapper.Map<data.Curso, Models.Curso>(curso);
            if (curso == null)
            {
                return NotFound();
            }

            new BS.Curso(_context).Delete(curso);

            return aux;
        }

        private bool CursoExists(int id)
        {
            return (new BS.Curso(_context).GetOneById(id) != null);
        }
    }
}
