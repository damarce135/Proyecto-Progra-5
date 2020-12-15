using EP.DAL.EF;
using EP.DAL.Repository;
using EP.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = EP.DO.Objects;

namespace EP.DAL
{
    public class CalEtiqueta : ICRUD<data.CalEtiqueta>
    {
        private Repository<data.CalEtiqueta> _repository = null;
        public CalEtiqueta(SolutionDBContext solutionDBContext)
        {
            _repository = new Repository<data.CalEtiqueta>(solutionDBContext);
        }
        public void Delete(data.CalEtiqueta t)
        {
            _repository.Delete(t);
            _repository.Commit();
        }

        public IEnumerable<data.CalEtiqueta> GetAll()
        {
            return _repository.GetAll();
        }

        public data.CalEtiqueta GetOneById(int id)
        {
            return _repository.GetOneById(id);
        }

        public void Insert(data.CalEtiqueta t)
        {
            _repository.Insert(t);
            _repository.Commit();
        }

        public void Update(data.CalEtiqueta t)
        {
            _repository.Update(t);
            _repository.Commit();
        }
    }
}
