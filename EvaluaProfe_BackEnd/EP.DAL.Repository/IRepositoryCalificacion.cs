using EP.DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EP.DAL.Repository
{
    public interface IRepositoryCalificacion : IRepository<Calificacion>
    {
        Task<IEnumerable<Calificacion>> GetAllWithCalificacionAsync();
        Task<Calificacion> GetWithCalificacionByIdAsync(int id);
    }
}
