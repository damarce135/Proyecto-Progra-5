using DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IRepositoryCurso : IRepository<Curso>
    {
        Task<IEnumerable<Curso>> GetAllWithCursosAsync();
        Task<Curso> GetWithCursoByIdAsync(int id);

    }
}
