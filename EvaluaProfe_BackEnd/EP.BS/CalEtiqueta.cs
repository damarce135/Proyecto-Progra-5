using EP.DAL.EF;
using EP.DO.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using data = EP.DO.Objects;

namespace EP.BS
{
    public class CalEtiqueta : ICRUD<data.CalEtiqueta>
    {
        private SolutionDBContext _solutionDBContext = null;

        public CalEtiqueta(SolutionDBContext solutionDBContext)
        {
            _solutionDBContext = solutionDBContext;
        }

        public void Delete(data.CalEtiqueta t)
        {
            new EP.DAL.CalEtiqueta(_solutionDBContext).Delete(t);
        }

        public IEnumerable<data.CalEtiqueta> GetAll()
        {
            return new EP.DAL.CalEtiqueta(_solutionDBContext).GetAll();
        }

        public data.CalEtiqueta GetOneById(int id)
        {
            return new EP.DAL.CalEtiqueta(_solutionDBContext).GetOneById(id);
        }

        public void Insert(data.CalEtiqueta t)
        {
            new EP.DAL.CalEtiqueta(_solutionDBContext).Insert(t);
        }

        public void Update(data.CalEtiqueta t)
        {
            new EP.DAL.CalEtiqueta(_solutionDBContext).Update(t);
        }
    }
}
