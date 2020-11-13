using EP.DAL.EF;
using EP.DAL.Repository;
using EP.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = EP.DO.Objects;

namespace EP.DAL
{
    public class Profesor : ICRUD<data.Profesor>
    {
        private Repository<data.Profesor> _repository = null;
        public Profesor(SolutionDBContext solutionDBContext)
        {
            _repository = new Repository<data.Profesor>(solutionDBContext);
        }
        public void Delete(data.Profesor t)
        {
            _repository.Delete(t);
            _repository.Commit();
        }

        public IEnumerable<data.Profesor> GetAll()
        {
            return _repository.GetAll();
        }

        public data.Profesor GetOneById(int id)
        {
            return _repository.GetOneById(id);
        }

        public void Insert(data.Profesor t)
        {
            _repository.Insert(t);
            _repository.Commit();
        }

        public void Update(data.Profesor t)
        {
            _repository.Update(t);
            _repository.Commit();
        }
    }
}
