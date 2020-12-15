using DAL.EF;
using DAL.Repository;
using DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = DO.Objects; 

namespace DAL
{
    public class Profesor : ICRUD<data.Profesor>
    {
        private Repository<data.Profesor> _repo = null;
        public Profesor(SolutionDBContext solutionDBContext)
        {
            _repo = new Repository<data.Profesor>(solutionDBContext);
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
