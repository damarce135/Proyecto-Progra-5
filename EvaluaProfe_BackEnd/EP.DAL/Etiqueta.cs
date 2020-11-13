using EP.DAL.EF;
using EP.DAL.Repository;
using EP.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = EP.DO.Objects;

namespace EP.DAL
{
    public class Etiqueta : ICRUD<data.Etiqueta>
    {
        private Repository<data.Etiqueta> _repository = null;
        public Etiqueta(SolutionDBContext solutionDBContext)
        {
            _repository = new Repository<data.Etiqueta>(solutionDBContext);
        }
        public void Delete(data.Etiqueta t)
        {
            _repository.Delete(t);
            _repository.Commit();
        }

        public IEnumerable<data.Etiqueta> GetAll()
        {
            return _repository.GetAll();
        }

        public data.Etiqueta GetOneById(int id)
        {
            return _repository.GetOneById(id);
        }

        public void Insert(data.Etiqueta t)
        {
            _repository.Insert(t);
            _repository.Commit();
        }

        public void Update(data.Etiqueta t)
        {
            _repository.Update(t);
            _repository.Commit();
        }
    }
}
