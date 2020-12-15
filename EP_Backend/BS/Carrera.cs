using DAL.EF;
using DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = DO.Objects; 

namespace BS
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
