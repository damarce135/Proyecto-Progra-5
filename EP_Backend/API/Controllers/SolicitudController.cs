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
    public class SolicitudController : ControllerBase
    {
        private readonly SolutionDBContext _context;
        private readonly IMapper _mapper;

        public SolicitudController(SolutionDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Solicituds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Solicitud>>> GetSolicituds()
        {
            var result = new BS.Solicitud(_context).GetAll().ToList();
            var aux = _mapper.Map<IEnumerable<data.Solicitud>, IEnumerable<Models.Solicitud>>(result);
            return aux.ToList();
        }

        // GET: api/Solicituds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Solicitud>> GetSolicitud(int id)
        {
            var solicitud = new BS.Solicitud(_context).GetOneById(id);
            var aux = _mapper.Map<data.Solicitud, Models.Solicitud>(solicitud);

            if (aux == null)
            {
                return NotFound();
            }

            return aux;
        }

        // PUT: api/Solicituds/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSolicitud(int id, Models.Solicitud solicitud)
        {
            if (id != solicitud.IdSolicitud)
            {
                return BadRequest();
            }

            try
            {
                var aux = _mapper.Map<Models.Solicitud, data.Solicitud>(solicitud);
                new BS.Solicitud(_context).Update(aux);
            }
            catch (Exception ee)
            {
                if (!SolicitudExists(id))
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

        // POST: api/Solicituds
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Models.Solicitud>> PostSolicitud(Models.Solicitud solicitud)
        {
            var aux = _mapper.Map<Models.Solicitud, data.Solicitud>(solicitud);
            new BS.Solicitud(_context).Insert(aux);

            return CreatedAtAction("GetSolicitud", new { id = solicitud.IdSolicitud }, solicitud);
        }

        // DELETE: api/Solicituds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.Solicitud>> DeleteSolicitud(int id)
        {
            var solicitud = new BS.Solicitud(_context).GetOneById(id);
            var aux = _mapper.Map<data.Solicitud, Models.Solicitud>(solicitud);
            if (solicitud == null)
            {
                return NotFound();
            }

            new BS.Solicitud(_context).Delete(solicitud);

            return aux;
        }

        private bool SolicitudExists(int id)
        {
            return (new BS.Solicitud(_context).GetOneById(id) != null);
        }
    }
}
