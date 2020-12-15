using DAL.EF;
using DAL.Repository;
using DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = DO.Objects; 

namespace DAL
{
    public class Etiqueta : ICRUD<data.Etiquetum>
    {
        private Repository<data.Etiquetum> _repo = null;
        public Etiqueta(SolutionDBContext solutionDBContext)
        {
            _repo = new Repository<data.Etiquetum>(solutionDBContext);
        }
        public void Delete(data.Etiquetum t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Etiquetum> GetAll()
        {
            return _repo.GetAll();
        }

        public data.Etiquetum GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.Etiquetum t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Etiquetum t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
