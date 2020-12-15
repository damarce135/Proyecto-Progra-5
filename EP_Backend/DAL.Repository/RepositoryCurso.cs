using DAL.EF;
using DO.Objects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class RepositoryCurso : Repository<Curso>, IRepositoryCurso 
    {
        public RepositoryCurso(SolutionDBContext context) : base(context)
        { }

        public async Task<IEnumerable<Curso>> GetAllWithCursosAsync()
        {
            return await SolutionDBContext.Cursos.Include(a => a.Carrera).ToListAsync();
        }

        public async Task<Curso> GetWithCursoByIdAsync(int id)
        {
            return await SolutionDBContext.Cursos.
                Include(a => a.Carrera).
                SingleOrDefaultAsync(z => z.IdCurso == id);
        }
        
        private SolutionDBContext SolutionDBContext
        {
            get { return dBContext as SolutionDBContext; }
        }
    }
}
