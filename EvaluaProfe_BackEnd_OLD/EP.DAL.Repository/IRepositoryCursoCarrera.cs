using EP.DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EP.DAL.Repository
{
    public interface IRepositoryCursoCarrera : IRepository<CursoCarrera>
    {
        Task<Carrera> AddCursoCarrera(CursoCarrera newCursoCarrera);

    }
}
