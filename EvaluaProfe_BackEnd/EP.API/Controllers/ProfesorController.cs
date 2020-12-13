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
    public class ProfesorController : ControllerBase
    {
        private readonly SolutionDBContext _context;
        private readonly IMapper _mapper;

        public ProfesorController(SolutionDBContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: api/Profesors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Profesor>>> GetProfesors()
        {
            var aux = await new BS.Profesor(_context).GetAllInclude();
            return _mapper.Map<IEnumerable<data.Profesor>, IEnumerable<Models.Profesor>>(aux).ToList();
        }

        // GET: api/Profesors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Profesor>> GetProfesor(int id)
        {
            var aux = await new BS.Profesor(_context).GetOneByIdInclude(id);
            var result = _mapper.Map<data.Profesor, Models.Profesor>(aux);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }

        // PUT: api/Profesors/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfesor(int id, Models.Profesor profesor)
        {
            if (id != profesor.IdProfesor)
            {
                return BadRequest();
            }

            try
            {
                var result = _mapper.Map<Models.Profesor, data.Profesor>(profesor);
                new BS.Profesor(_context).Update(result);
            }
            catch (Exception ee)
            {
                if (!ProfesorExists(id))
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

        // POST: api/Profesors
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Models.Profesor>> PostProfesor(Models.Profesor profesor)
        {
            var result = _mapper.Map<Models.Profesor, data.Profesor>(profesor);
            new BS.Profesor(_context).Insert(result);

            return CreatedAtAction("GetProfesor", new { id = profesor.IdProfesor }, profesor);
        }

        // DELETE: api/Profesors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.Profesor>> DeleteProfesor(int id)
        {
            var profesor = new BS.Profesor(_context).GetOneById(id);
            var result = _mapper.Map<data.Profesor, Models.Profesor>(profesor);

            if (profesor == null)
            {
                return NotFound();
            }
            new BS.Profesor(_context).Delete(profesor);

            return result;
        }

        private bool ProfesorExists(int id)
        {
            return (new BS.Profesor(_context).GetOneById(id) != null);
        }
    }
}
