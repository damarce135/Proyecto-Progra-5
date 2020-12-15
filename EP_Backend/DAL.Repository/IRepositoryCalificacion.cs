using DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IRepositoryCalificacion : IRepository<Calificacion>
    {
        Task<IEnumerable<Calificacion>> GetAllWithCalificacionsAsync();
        Task<Calificacion> GetWithCalificacionByIdAsync(int id);
    }
}
