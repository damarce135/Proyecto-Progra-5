using AutoMapper;
using EP.DAL.EF;
using EP.DO.Objects;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EP.DAL.Repository
{
    public class RepositoryCursoCarrera : Repository<CursoCarrera>, IRepositoryCursoCarrera
    {

        private readonly SolutionDBContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public RepositoryCursoCarrera(SolutionDBContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(context)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }


        public async Task<Carrera> AddCursoCarrera(CursoCarrera newCursoCarrera)
        {
            Carrera response = new Carrera();
            try
            {
                Carrera carrera = await _context.Carrera
                    .Include(c => c.CursoCarreras).ThenInclude(cs => cs.Curso)
                    .FirstOrDefaultAsync(c => c.IdCarrera == newCursoCarrera.IdCarrera);

                Curso curso = await _context.Curso
                    .FirstOrDefaultAsync(s => s.IdCurso == newCursoCarrera.IdCurso);

                CursoCarrera cursoCarrera = new CursoCarrera
                {
                    Carrera = carrera,
                    Curso = curso
                };

                await _context.CursoCarrera.AddAsync(cursoCarrera);
                await _context.SaveChangesAsync();
                //response.Data = _mapper.Map<Carrera>(carrera);
            }
            catch (Exception ex)
            {
            }
            return response;
        }

    }
}
