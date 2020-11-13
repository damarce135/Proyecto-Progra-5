using EP.DAL.EF;
using EP.DAL.Repository;
using EP.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = EP.DO.Objects;

namespace EP.DAL
{
    public class Curso : ICRUD<data.Curso>
    {
        private Repository<data.Curso> _repository = null;
        public Curso(SolutionDBContext solutionDBContext)
        {
            _repository = new Repository<data.Curso>(solutionDBContext);
        }
        public void Delete(data.Curso t)
        {
            _repository.Delete(t);
            _repository.Commit();
        }

        public IEnumerable<data.Curso> GetAll()
        {
            return _repository.GetAll();
        }

        public data.Curso GetOneById(int id)
        {
            return _repository.GetOneById(id);
        }

        public void Insert(data.Curso t)
        {
            _repository.Insert(t);
            _repository.Commit();
        }

        public void Update(data.Curso t)
        {
            _repository.Update(t);
            _repository.Commit();
        }
    }
}
