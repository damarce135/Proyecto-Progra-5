using EP.DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EP.DAL.Repository
{
    public interface IRepositoryCarrera : IRepository<Carrera>
    {
        Task<IEnumerable<Carrera>> GetAllWithCarreraAsync();
        Task<Carrera> GetWithCarreraByIdAsync(int id);
    }
}
