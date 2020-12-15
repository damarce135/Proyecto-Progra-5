using DAL.EF;
using DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = DO.Objects; 

namespace BS
{
    public class Etiqueta : ICRUD<data.Etiquetum>
    {
        private SolutionDBContext _repo = null;
        public Etiqueta(SolutionDBContext solutionDBContext)
        {
            _repo = solutionDBContext;
        }
        public void Delete(data.Etiquetum t)
        {
            new DAL.Etiqueta(_repo).Delete(t);
        }

        public IEnumerable<data.Etiquetum> GetAll()
        {
            return new DAL.Etiqueta(_repo).GetAll();
        }

        public data.Etiquetum GetOneById(int id)
        {
            return new DAL.Etiqueta(_repo).GetOneById(id);
        }

        public void Insert(data.Etiquetum t)
        {
            new DAL.Etiqueta(_repo).Insert(t);
        }

        public void Update(data.Etiquetum t)
        {
            new DAL.Etiqueta(_repo).Update(t);
        }
    }
}
