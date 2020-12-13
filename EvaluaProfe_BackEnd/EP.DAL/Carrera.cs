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
    public class Carrera : ICRUD<data.Carrera>
    {
        private RepositoryCarrera _repo = null;
        public Carrera(SolutionDBContext solutionDBContext)
        {
            _repo = new RepositoryCarrera(solutionDBContext);
        }
        public void Delete(data.Carrera t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Carrera> GetAll()
        {
            return _repo.GetAll();
        }

        public data.Carrera GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }
        public async Task<IEnumerable<data.Carrera>> GetAllInclude()
        {
            return await _repo.GetAllWithCarreraAsync();
        }

        public async Task<data.Carrera> GetOneByIdInclude(int id)
        {
            return await _repo.GetWithCarreraByIdAsync(id);
        }

        public void Insert(data.Carrera t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Carrera t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
