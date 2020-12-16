using DAL.EF;
using DAL.Repository;
using DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = DO.Objects; 

namespace DAL
{
    public class Solicitud : ICRUD<data.Solicitud>
    {
        private Repository<data.Solicitud> _repo = null;
        public Solicitud(SolutionDBContext solutionDBContext)
        {
            _repo = new Repository<data.Solicitud>(solutionDBContext);
        }
        public void Delete(data.Solicitud t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Solicitud> GetAll()
        {
            return _repo.GetAll();
        }

        public data.Solicitud GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.Solicitud t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Solicitud t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
