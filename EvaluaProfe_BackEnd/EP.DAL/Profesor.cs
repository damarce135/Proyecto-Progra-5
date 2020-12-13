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
    public class Profesor : ICRUD<data.Profesor>
    {
        private RepositoryProfesor _repo = null;
        public Profesor(SolutionDBContext solutionDBContext)
        {
            _repo = new RepositoryProfesor(solutionDBContext);
        }
        public void Delete(data.Profesor t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Profesor> GetAll()
        {
            return _repo.GetAll();
        }

        public data.Profesor GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }
        public async Task<IEnumerable<data.Profesor>> GetAllInclude()
        {
            return await _repo.GetAllWithProfesorAsync();
        }

        public async Task<data.Profesor> GetOneByIdInclude(int id)
        {
            return await _repo.GetWithProfesorByIdAsync(id);
        }

        public void Insert(data.Profesor t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Profesor t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
