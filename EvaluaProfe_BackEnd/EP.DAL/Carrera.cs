using EP.DAL.EF;
using EP.DAL.Repository;
using EP.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = EP.DO.Objects;

namespace EP.DAL
{
    public class Carrera : ICRUD<data.Carrera>
    {
        private Repository<data.Carrera> _repository = null;
        public Carrera(SolutionDBContext solutionDBContext)
        {
            _repository = new Repository<data.Carrera>(solutionDBContext);
        }
        public void Delete(data.Carrera t)
        {
            _repository.Delete(t);
            _repository.Commit();
        }

        public IEnumerable<data.Carrera> GetAll()
        {
            return _repository.GetAll();
        }

        public data.Carrera GetOneById(int id)
        {
            return _repository.GetOneById(id);
        }

        public void Insert(data.Carrera t)
        {
            _repository.Insert(t);
            _repository.Commit();
        }

        public void Update(data.Carrera t)
        {
            _repository.Update(t);
            _repository.Commit();
        }
    }
}
