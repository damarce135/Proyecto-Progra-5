using EP.DAL.EF;
using EP.DAL.Repository;
using EP.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = EP.DO.Objects;

namespace EP.DAL
{
    public class ProfUniversidad : ICRUD<data.ProfUniversidad>
    {
        private Repository<data.ProfUniversidad> _repository = null;
        public ProfUniversidad(SolutionDBContext solutionDBContext)
        {
            _repository = new Repository<data.ProfUniversidad>(solutionDBContext);
        }
        public void Delete(data.ProfUniversidad t)
        {
            _repository.Delete(t);
            _repository.Commit();
        }

        public IEnumerable<data.ProfUniversidad> GetAll()
        {
            return _repository.GetAll();
        }

        public data.ProfUniversidad GetOneById(int id)
        {
            return _repository.GetOneById(id);
        }

        public void Insert(data.ProfUniversidad t)
        {
            _repository.Insert(t);
            _repository.Commit();
        }

        public void Update(data.ProfUniversidad t)
        {
            _repository.Update(t);
            _repository.Commit();
        }
    }
}