using DAL.EF;
using DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DO.Objects; 

namespace BS
{
    public class Curso : ICRUD<data.Curso>
    {
        private SolutionDBContext _repo = null;
        public Curso(SolutionDBContext solutionDBContext)
        {
            _repo = solutionDBContext;
        }
        public void Delete(data.Curso t)
        {
            new DAL.Curso(_repo).Delete(t);
        }

        public IEnumerable<data.Curso> GetAll()
        {
            return new DAL.Curso(_repo).GetAll();
        }

        public data.Curso GetOneById(int id)
        {
            return new DAL.Curso(_repo).GetOneById(id);
        }
        public async Task<IEnumerable<data.Curso>> GetAllInclude()
        {
            return await new DAL.Curso(_repo).GetAllInclude();
        }

        public async Task<data.Curso> GetOneByIdInclude(int id)
        {
            return await new DAL.Curso(_repo).GetOneByIdInclude(id);
        }

        public void Insert(data.Curso t)
        {
            new DAL.Curso(_repo).Insert(t);
        }

        public void Update(data.Curso t)
        {
            new DAL.Curso(_repo).Update(t);
        }
    }
}
