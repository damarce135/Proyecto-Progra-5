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
    public class CalificacionController : ControllerBase
    {
        private readonly SolutionDBContext _context;
        private readonly IMapper _mapper;

        public CalificacionController(SolutionDBContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: api/Calificacions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Calificacion>>> GetCalificacions()
        {
            var aux = await new BS.Calificacion(_context).GetAllInclude();
            return _mapper.Map<IEnumerable<data.Calificacion>, IEnumerable<Models.Calificacion>>(aux).ToList();
        }

        // GET: api/Calificacions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Calificacion>> GetCalificacion(int id)
        {
            var aux = await new BS.Calificacion(_context).GetOneByIdInclude(id);
            var result = _mapper.Map<data.Calificacion, Models.Calificacion>(aux);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }

        // PUT: api/Calificacions/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalificacion(int id, Models.Calificacion calificacion)
        {
            if (id != calificacion.IdCalificacion)
            {
                return BadRequest();
            }

            try
            {
                var result = _mapper.Map<Models.Calificacion, data.Calificacion>(calificacion);
                new BS.Calificacion(_context).Update(result);
            }
            catch (Exception ee)
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

        // POST: api/Calificacions
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Models.Calificacion>> PostCalificacion(Models.Calificacion calificacion)
        {
            var result = _mapper.Map<Models.Calificacion, data.Calificacion>(calificacion);
            new BS.Calificacion(_context).Insert(result);

            return CreatedAtAction("GetCalificacion", new { id = calificacion.IdCalificacion }, calificacion);
        }

        // DELETE: api/Calificacions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.Calificacion>> DeleteCalificacion(int id)
        {
            var calificacion = new BS.Calificacion(_context).GetOneById(id);
            var result = _mapper.Map<data.Calificacion, Models.Calificacion>(calificacion);

            if (calificacion == null)
            {
                return NotFound();
            }
            new BS.Calificacion(_context).Delete(calificacion);

            return result;
        }

        private bool CalificacionExists(int id)
        {
            return (new BS.Calificacion(_context).GetOneById(id) != null);
        }
    }
}
