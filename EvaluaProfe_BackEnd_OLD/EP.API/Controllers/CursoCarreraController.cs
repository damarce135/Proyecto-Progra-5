using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EP.DAL.EF;
using EP.DAL.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using data = EP.DO.Objects;

namespace EP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoCarreraController : ControllerBase
    {
        private readonly SolutionDBContext _context;
        private readonly IMapper _mapper;
        private readonly IRepositoryCursoCarrera _repositoryCursoCarrera;

        public CursoCarreraController(SolutionDBContext context, IMapper mapper, IRepositoryCursoCarrera repositoryCursoCarrera)
        {
            _context = context;
            _mapper = mapper;
            _repositoryCursoCarrera = repositoryCursoCarrera;
        }

        //[HttpPost]
        //public async Task<IActionResult> AddCursoCarrera(data.CursoCarrera newCursoCarrera)
        //{
        //    return Ok(await _repositoryCursoCarrera.AddCursoCarrera(newCursoCarrera));
        //}

        // GET: api/CursoCarreras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.CursoCarrera>>> GetCursoCarreras()
        {
            var result = new BS.CursoCarrera(_context).GetAll().ToList();
            var aux = _mapper.Map<IEnumerable<data.CursoCarrera>, IEnumerable<Models.CursoCarrera>>(result);
            return aux.ToList();
        }

        // GET: api/CursoCarreras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.CursoCarrera>> GetCursoCarrera(int id)
        {
            var cursoCarrera = new BS.CursoCarrera(_context).GetOneById(id);
            var aux = _mapper.Map<data.CursoCarrera, Models.CursoCarrera>(cursoCarrera);

            if (aux == null)
            {
                return NotFound();
            }

            return aux;
        }

        // PUT: api/CursoCarreras/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCursoCarrera(int id, Models.CursoCarrera cursoCarrera)
        {
            if (id != cursoCarrera.IdCursoCarrera)
            {
                return BadRequest();
            }

            try
            {
                var aux = _mapper.Map<Models.CursoCarrera, data.CursoCarrera>(cursoCarrera);
                new BS.CursoCarrera(_context).Update(aux);
            }
            catch (Exception ee)
            {
                if (!CursoCarreraExists(id))
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

        // POST: api/CursoCarreras
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Models.CursoCarrera>> PostCursoCarrera(Models.CursoCarrera cursoCarrera)
        {
            var aux = _mapper.Map<Models.CursoCarrera, data.CursoCarrera>(cursoCarrera);
            new BS.CursoCarrera(_context).Insert(aux);

            return CreatedAtAction("GetCursoCarrera", new { id = cursoCarrera.IdCursoCarrera }, cursoCarrera);
        }

        // DELETE: api/CursoCarreras/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.CursoCarrera>> DeleteCursoCarrera(int id)
        {
            var cursoCarrera = new BS.CursoCarrera(_context).GetOneById(id);
            var aux = _mapper.Map<data.CursoCarrera, Models.CursoCarrera>(cursoCarrera);
            if (cursoCarrera == null)
            {
                return NotFound();
            }

            new BS.CursoCarrera(_context).Delete(cursoCarrera);

            return aux;
        }

        private bool CursoCarreraExists(int id)
        {
            return (new BS.CursoCarrera(_context).GetOneById(id) != null);
        }
    }
}
