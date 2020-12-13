using EP.DAL.EF;
using EP.DAL.Repository;
using EP.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = EP.DO.Objects;

namespace EP.DAL
{
    public class Calificacion : ICRUD<data.Calificacion>
    {
        private RepositoryCalificacion _repo = null;
        public Calificacion(SolutionDBContext solutionDBContext)
        {
            _repo = new RepositoryCalificacion(solutionDBContext);
        }
        public void Delete(data.Calificacion t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Calificacion> GetAll()
        {
            return _repo.GetAll();
        }

        public data.Calificacion GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }
        public async Task<IEnumerable<data.Calificacion>> GetAllInclude()
        {
            return await _repo.GetAllWithCalificacionAsync();
        }

        public async Task<data.Calificacion> GetOneByIdInclude(int id)
        {
            return await _repo.GetWithCalificacionByIdAsync(id);
        }

        public void Insert(data.Calificacion t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Calificacion t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
