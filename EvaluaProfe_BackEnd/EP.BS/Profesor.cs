using EP.DAL.EF;
using EP.DO.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = EP.DO.Objects;

namespace EP.BS
{
    public class Profesor : ICRUD<data.Profesor>
    {
        private SolutionDBContext _repo = null;
        public Profesor(SolutionDBContext solutionDBContext)
        {
            _repo = solutionDBContext;
        }
        public void Delete(data.Profesor t)
        {
            new DAL.Profesor(_repo).Delete(t);
        }

        public IEnumerable<data.Profesor> GetAll()
        {
            return new DAL.Profesor(_repo).GetAll();
        }

        public data.Profesor GetOneById(int id)
        {
            return new DAL.Profesor(_repo).GetOneById(id);
        }
        public async Task<IEnumerable<data.Profesor>> GetAllInclude()
        {
            return await new DAL.Profesor(_repo).GetAllInclude();
        }

        public async Task<data.Profesor> GetOneByIdInclude(int id)
        {
            return await new DAL.Profesor(_repo).GetOneByIdInclude(id);
        }

        public void Insert(data.Profesor t)
        {
            new DAL.Profesor(_repo).Insert(t);
        }

        public void Update(data.Profesor t)
        {
            new DAL.Profesor(_repo).Update(t);
        }
    }
}
