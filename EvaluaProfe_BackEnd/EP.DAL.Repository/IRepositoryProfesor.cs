using EP.DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EP.DAL.Repository
{
    public interface IRepositoryProfesor : IRepository<Profesor>
    {
        Task<IEnumerable<Profesor>> GetAllWithProfesorAsync();
        Task<Profesor> GetWithProfesorByIdAsync(int id);
    }
}
