using EP.DAL.EF;
using EP.DO.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using data = EP.DO.Objects;

namespace EP.BS
{
    public class Calificacion : ICRUD<data.Calificacion>
    {
        private SolutionDBContext _solutionDBContext = null;

        public Calificacion(SolutionDBContext solutionDBContext)
        {
            _solutionDBContext = solutionDBContext;
        }

        public void Delete(data.Calificacion t)
        {
            new EP.DAL.Calificacion(_solutionDBContext).Delete(t);
        }

        public IEnumerable<data.Calificacion> GetAll()
        {
            return new EP.DAL.Calificacion(_solutionDBContext).GetAll();
        }

        public data.Calificacion GetOneById(int id)
        {
            return new EP.DAL.Calificacion(_solutionDBContext).GetOneById(id);
        }

        public void Insert(data.Calificacion t)
        {
            new EP.DAL.Calificacion(_solutionDBContext).Insert(t);
        }

        public void Update(data.Calificacion t)
        {
            new EP.DAL.Calificacion(_solutionDBContext).Update(t);
        }
    }
}
