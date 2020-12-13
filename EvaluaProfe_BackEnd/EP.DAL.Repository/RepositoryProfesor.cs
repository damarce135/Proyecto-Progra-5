using EP.DAL.EF;
using EP.DO.Objects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EP.DAL.Repository
{
    public class RepositoryProfesor : Repository<Profesor>, IRepositoryProfesor
    {

        
        public RepositoryProfesor(SolutionDBContext context) : base(context)
        { }

        public async Task<IEnumerable<Profesor>> GetAllWithProfesorAsync()
        {
            return await SolutionDBContext.Profesor.Include(a => a.Cursos).ToListAsync();
        }

        public async Task<Profesor> GetWithProfesorByIdAsync(int id)
        {
            return await SolutionDBContext.Profesor.
                Include(a => a.Cursos).
                SingleOrDefaultAsync(z => z.IdProfesor == id);
        }
       
        private SolutionDBContext SolutionDBContext
        {
            get { return dbContext as SolutionDBContext; }
        }
    }
}
