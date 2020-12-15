using DAL.EF;
using DAL.Repository;
using DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DO.Objects; 

namespace DAL
{
    public class Curso : ICRUD<data.Curso>
    {
        private RepositoryCurso _repo = null;
        public Curso(SolutionDBContext solutionDBContext)
        {
            _repo = new RepositoryCurso(solutionDBContext);
        }
        public void Delete(data.Curso t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Curso> GetAll()
        {
            return _repo.GetAll();
        }

        public data.Curso GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }
        public async Task<IEnumerable<data.Curso>> GetAllInclude()
        {
            return await _repo.GetAllWithCursosAsync();
        }

        public async Task<data.Curso> GetOneByIdInclude(int id)
        {
            return await _repo.GetWithCursoByIdAsync(id);
        }

        public void Insert(data.Curso t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Curso t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
