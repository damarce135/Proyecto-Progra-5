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
    public class CarreraController : ControllerBase
    {
        private readonly SolutionDBContext _context;
        private readonly IMapper _mapper;

        public CarreraController(SolutionDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Carreras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Carrera>>> GetCarreras()
        {
            var result = new BS.Carrera(_context).GetAll().ToList();
            var aux = _mapper.Map<IEnumerable<data.Carrera>, IEnumerable<Models.Carrera>>(result);
            return aux.ToList();
        }

        // GET: api/Carreras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Carrera>> GetCarrera(int id)
        {
            var carrera = new BS.Carrera(_context).GetOneById(id);
            var aux = _mapper.Map<data.Carrera, Models.Carrera>(carrera);

            if (aux == null)
            {
                return NotFound();
            }

            return aux;
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
                var aux = _mapper.Map<Models.Carrera, data.Carrera>(carrera);
                new BS.Carrera(_context).Update(aux);
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
            var aux = _mapper.Map<Models.Carrera, data.Carrera>(carrera);
            new BS.Carrera(_context).Insert(aux);

            return CreatedAtAction("GetCarrera", new { id = carrera.IdCarrera }, carrera);
        }

        // DELETE: api/Carreras/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.Carrera>> DeleteCarrera(int id)
        {
            var carrera = new BS.Carrera(_context).GetOneById(id);
            var aux = _mapper.Map<data.Carrera, Models.Carrera>(carrera);
            if (carrera == null)
            {
                return NotFound();
            }

            new BS.Carrera(_context).Delete(carrera);

            return aux;
        }

        private bool CarreraExists(int id)
        {
            return (new BS.Carrera(_context).GetOneById(id) != null);
        }
    }
}
