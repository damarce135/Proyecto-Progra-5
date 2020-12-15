using DAL.EF;
using DO.Objects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class RepositoryCalificacion : Repository<Calificacion>, IRepositoryCalificacion
    {

        public RepositoryCalificacion(SolutionDBContext context) : base(context)
        { }

        public async Task<IEnumerable<Calificacion>> GetAllWithCalificacionsAsync()
        {
            return await SolutionDBContext.Calificacions.Include(a => a.Profesor).Include(a => a.Carrera).Include(a => a.Curso).Include(a => a.Etiqueta).ToListAsync();
        }

        public async Task<Calificacion> GetWithCalificacionByIdAsync(int id)
        {
            return await SolutionDBContext.Calificacions.
                Include(a => a.Profesor).Include(a => a.Carrera).Include(a => a.Curso).Include(a => a.Etiqueta).
                SingleOrDefaultAsync(z => z.IdCalificacion == id);
        }
        
        private SolutionDBContext SolutionDBContext
        {
            get { return dBContext as SolutionDBContext; }
        }
    }
}
