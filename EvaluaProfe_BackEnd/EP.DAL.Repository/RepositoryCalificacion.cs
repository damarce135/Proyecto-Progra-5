using EP.DAL.EF;
using EP.DO.Objects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EP.DAL.Repository
{
    public class RepositoryCalificacion : Repository<Calificacion>, IRepositoryCalificacion
    {

        
        public RepositoryCalificacion(SolutionDBContext context) : base(context)
        { }

        public async Task<IEnumerable<Calificacion>> GetAllWithCalificacionAsync()
        {
            return await SolutionDBContext.Calificacion.Include(a => a.Etiquetas).Include(a => a.Profesor).
                Include(a => a.Curso).ToListAsync();
        }

        public async Task<Calificacion> GetWithCalificacionByIdAsync(int id)
        {
            return await SolutionDBContext.Calificacion.
                Include(a => a.Etiquetas).
                Include(a => a.Profesor).
                Include(a => a.Curso).
                SingleOrDefaultAsync(z => z.IdCalificacion == id);
        }
       
        private SolutionDBContext SolutionDBContext
        {
            get { return dbContext as SolutionDBContext; }
        }
    }
}
