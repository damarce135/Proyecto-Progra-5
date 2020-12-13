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
    public class Carrera : ICRUD<data.Carrera>
    {
        private SolutionDBContext _repo = null;
        public Carrera(SolutionDBContext solutionDBContext)
        {
            _repo = solutionDBContext;
        }
        public void Delete(data.Carrera t)
        {
            new DAL.Carrera(_repo).Delete(t);
        }

        public IEnumerable<data.Carrera> GetAll()
        {
            return new DAL.Carrera(_repo).GetAll();
        }

        public data.Carrera GetOneById(int id)
        {
            return new DAL.Carrera(_repo).GetOneById(id);
        }
        public async Task<IEnumerable<data.Carrera>> GetAllInclude()
        {
            return await new DAL.Carrera(_repo).GetAllInclude();
        }

        public async Task<data.Carrera> GetOneByIdInclude(int id)
        {
            return await new DAL.Carrera(_repo).GetOneByIdInclude(id);
        }

        public void Insert(data.Carrera t)
        {
            new DAL.Carrera(_repo).Insert(t);
        }

        public void Update(data.Carrera t)
        {
            new DAL.Carrera(_repo).Update(t);
        }
    }
}
