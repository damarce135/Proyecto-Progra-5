using DAL.EF;
using DAL.Repository;
using DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = DO.Objects; 

namespace DAL
{
    public class Carrera : ICRUD<data.Carrera>
    {
        private Repository<data.Carrera> _repo = null;
        public Carrera(SolutionDBContext solutionDBContext)
        {
            _repo = new Repository<data.Carrera>(solutionDBContext);
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
