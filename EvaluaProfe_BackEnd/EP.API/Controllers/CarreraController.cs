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
    public class CarreraController : ControllerBase
    {
        private readonly SolutionDBContext _context;
        private readonly IMapper _mapper;

        public CarreraController(SolutionDBContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: api/Carreras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Carrera>>> GetCarreras()
        {
            var aux = await new BS.Carrera(_context).GetAllInclude();
            return _mapper.Map<IEnumerable<data.Carrera>, IEnumerable<Models.Carrera>>(aux).ToList();
        }

        // GET: api/Carreras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Carrera>> GetCarrera(int id)
        {
            var aux = await new BS.Carrera(_context).GetOneByIdInclude(id);
            var result = _mapper.Map<data.Carrera, Models.Carrera>(aux);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }

        // PUT: api/Carreras/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarrera(int id, Models.Carrera carrera)
        {
            if (id != carrera.IdCarrera)
            {
                return BadRequest();
            }

            try
            {
                var result = _mapper.Map<Models.Carrera, data.Carrera>(carrera);
                new BS.Carrera(_context).Update(result);
            }
            catch (Exception ee)
            {
                if (!CarreraExists(id))
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

        // POST: api/Carreras
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Models.Carrera>> PostCarrera(Models.Carrera carrera)
        {
            var result = _mapper.Map<Models.Carrera, data.Carrera>(carrera);
            new BS.Carrera(_context).Insert(result);

            return CreatedAtAction("GetCarrera", new { id = carrera.IdCarrera }, carrera);
        }

        // DELETE: api/Carreras/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.Carrera>> DeleteCarrera(int id)
        {
            var carrera = new BS.Carrera(_context).GetOneById(id);
            var result = _mapper.Map<data.Carrera, Models.Carrera>(carrera);

            if (carrera == null)
            {
                return NotFound();
            }
            new BS.Carrera(_context).Delete(carrera);

            return result;
        }

        private bool CarreraExists(int id)
        {
            return (new BS.Carrera(_context).GetOneById(id) != null);
        }
    }
}
