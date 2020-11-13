using EP.DAL.EF;
using EP.DAL.Repository;
using EP.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = EP.DO.Objects;

namespace EP.DAL
{
    public class Calificacion : ICRUD<data.Calificacion>
    {
        private Repository<data.Calificacion> _repository = null;
        public Calificacion(SolutionDBContext solutionDBContext)
        {
            _repository = new Repository<data.Calificacion>(solutionDBContext);
        }
        public void Delete(data.Calificacion t)
        {
            _repository.Delete(t);
            _repository.Commit();
        }

        public IEnumerable<data.Calificacion> GetAll()
        {
            return _repository.GetAll();
        }

        public data.Calificacion GetOneById(int id)
        {
            return _repository.GetOneById(id);
        }

        public void Insert(data.Calificacion t)
        {
            _repository.Insert(t);
            _repository.Commit();
        }

        public void Update(data.Calificacion t)
        {
            _repository.Update(t);
            _repository.Commit();
        }
    }
}
