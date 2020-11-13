using EP.DAL.EF;
using EP.DAL.Repository;
using EP.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = EP.DO.Objects;

namespace EP.DAL
{
    public class ProfCurso : ICRUD<data.ProfCurso>
    {
        private Repository<data.ProfCurso> _repository = null;
        public ProfCurso(SolutionDBContext solutionDBContext)
        {
            _repository = new Repository<data.ProfCurso>(solutionDBContext);
        }
        public void Delete(data.ProfCurso t)
        {
            _repository.Delete(t);
            _repository.Commit();
        }

        public IEnumerable<data.ProfCurso> GetAll()
        {
            return _repository.GetAll();
        }

        public data.ProfCurso GetOneById(int id)
        {
            return _repository.GetOneById(id);
        }

        public void Insert(data.ProfCurso t)
        {
            _repository.Insert(t);
            _repository.Commit();
        }

        public void Update(data.ProfCurso t)
        {
            _repository.Update(t);
            _repository.Commit();
        }
    }
}
