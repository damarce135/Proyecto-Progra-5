using DAL.EF;
using DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = DO.Objects; 

namespace BS
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
