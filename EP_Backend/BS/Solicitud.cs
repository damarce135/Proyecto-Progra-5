using DAL.EF;
using DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = DO.Objects; 

namespace BS
{
    public class Solicitud : ICRUD<data.Solicitud>
    {
        private SolutionDBContext _repo = null;
        public Solicitud(SolutionDBContext solutionDBContext)
        {
            _repo = solutionDBContext;
        }
        public void Delete(data.Solicitud t)
        {
            new DAL.Solicitud(_repo).Delete(t);
        }

        public IEnumerable<data.Solicitud> GetAll()
        {
            return new DAL.Solicitud(_repo).GetAll();
        }

        public data.Solicitud GetOneById(int id)
        {
            return new DAL.Solicitud(_repo).GetOneById(id);
        }

        public void Insert(data.Solicitud t)
        {
            new DAL.Solicitud(_repo).Insert(t);
        }

        public void Update(data.Solicitud t)
        {
            new DAL.Solicitud(_repo).Update(t);
        }
    }
}
