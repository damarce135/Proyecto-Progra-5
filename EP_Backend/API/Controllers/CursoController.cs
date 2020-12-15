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
    public class CursoController : ControllerBase
    {
        private readonly SolutionDBContext _context;
        private readonly IMapper _mapper;

        public CursoController(SolutionDBContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: api/Cursos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Curso>>> GetCursos()
        {
            var aux = await new BS.Curso(_context).GetAllInclude();
            return _mapper.Map<IEnumerable<data.Curso>, IEnumerable<Models.Curso>>(aux).ToList();
        }

        // GET: api/Cursos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Curso>> GetCurso(int id)
        {
            var aux = await new BS.Curso(_context).GetOneByIdInclude(id);
            var result = _mapper.Map<data.Curso, Models.Curso>(aux);
            if (result == null)
            {
                return NotFound();
            }
            return result;
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
                var result = _mapper.Map<Models.Curso, data.Curso>(curso);
                new BS.Curso(_context).Update(result);
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
            var result = _mapper.Map<Models.Curso, data.Curso>(curso);
            new BS.Curso(_context).Insert(result);

            return CreatedAtAction("GetCurso", new { id = curso.IdCurso }, curso);
        }

        // DELETE: api/Cursos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.Curso>> DeleteCurso(int id)
        {
            var curso = new BS.Curso(_context).GetOneById(id);
            var result = _mapper.Map<data.Curso, Models.Curso>(curso);

            if (curso == null)
            {
                return NotFound();
            }
            new BS.Curso(_context).Delete(curso);

            return result;
        }

        private bool CursoExists(int id)
        {
            return (new BS.Curso(_context).GetOneById(id) != null);
        }
    }
}
