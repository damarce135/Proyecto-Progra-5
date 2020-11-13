﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EP.DAL.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using data = EP.DO.Objects;

namespace EP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversidadController : ControllerBase
    {
        private readonly SolutionDBContext _context;

        public UniversidadController(SolutionDBContext context)
        {
            _context = context;
        }

        // GET: api/Universidad
        [HttpGet]
        public async Task<ActionResult<IEnumerable<data.Universidad>>> GetUniversidad()
        {
            return new BS.Universidad(_context).GetAll().ToList();
        }

        // GET: api/Universidad/5
        [HttpGet("{id}")]
        public async Task<ActionResult<data.Universidad>> GetUniversidad(int id)
        {
            var universidad = new BS.Universidad(_context).GetOneById(id);

            if (universidad == null)
            {
                return NotFound();
            }

            return universidad;
        }

        // PUT: api/Universidad/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUniversidad(int id, data.Universidad universidad)
        {
            if (id != universidad.IdUniversidad)
            {
                return BadRequest();
            }

            //_context.Entry(universidad).State = EntityState.Modified;

            try
            {
                new BS.Universidad(_context).Update(universidad);
            }
            catch (Exception)
            {
                if (!UniversidadExists(id))
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

        // POST: api/Universidad
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<data.Universidad>> PostUniversidad(data.Universidad universidad)
        {
            new BS.Universidad(_context).Insert(universidad);

            return CreatedAtAction("GetUniversidad", new { id = universidad.IdUniversidad }, universidad);
        }

        // DELETE: api/Universidad/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<data.Universidad>> DeleteUniversidad(int id)
        {
            var universidad = new BS.Universidad(_context).GetOneById(id);
            if (universidad == null)
            {
                return NotFound();
            }

            new BS.Universidad(_context).Delete(universidad);

            return universidad;
        }

        private bool UniversidadExists(int id)
        {
            return (new BS.Universidad(_context).GetOneById(id) != null);
        }
    }
}
