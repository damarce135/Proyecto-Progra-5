using EP.DAL.EF;
using EP.DAL.Repository;
using EP.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = EP.DO.Objects;

namespace EP.DAL
{
    public class CursoCarrera : ICRUD<data.CursoCarrera>
    {
        private Repository<data.CursoCarrera> _repository = null;
        public CursoCarrera(SolutionDBContext solutionDBContext)
        {
            _repository = new Repository<data.CursoCarrera>(solutionDBContext);
        }
        public void Delete(data.CursoCarrera t)
        {
            _repository.Delete(t);
            _repository.Commit();
        }

        public IEnumerable<data.CursoCarrera> GetAll()
        {
            return _repository.GetAll();
        }

        public data.CursoCarrera GetOneById(int id)
        {
            return _repository.GetOneById(id);
        }

        public void Insert(data.CursoCarrera t)
        {
            _repository.Insert(t);
            _repository.Commit();
        }

        public void Update(data.CursoCarrera t)
        {
            _repository.Update(t);
            _repository.Commit();
        }
    }
}
