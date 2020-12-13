using EP.DAL.EF;
using EP.DO.Objects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EP.DAL.Repository
{
    public class RepositoryCarrera : Repository<Carrera>, IRepositoryCarrera
    {

        
        public RepositoryCarrera(SolutionDBContext context) : base(context)
        { }

        public async Task<IEnumerable<Carrera>> GetAllWithCarreraAsync()
        {
            return await SolutionDBContext.Carrera.Include(a => a.Cursos).ToListAsync();
        }

        public async Task<Carrera> GetWithCarreraByIdAsync(int id)
        {
            return await SolutionDBContext.Carrera.
                Include(a => a.Cursos).
                SingleOrDefaultAsync(z => z.IdCarrera == id);
        }
       
        private SolutionDBContext SolutionDBContext
        {
            get { return dbContext as SolutionDBContext; }
        }
    }
}
