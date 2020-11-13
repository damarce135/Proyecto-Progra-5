using EP.DAL.EF;
using EP.DO.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using data = EP.DO.Objects;

namespace EP.BS
{
    public class CursoCarrera : ICRUD<data.CursoCarrera>
    {
        private SolutionDBContext _solutionDBContext = null;

        public CursoCarrera(SolutionDBContext solutionDBContext)
        {
            _solutionDBContext = solutionDBContext;
        }

        public void Delete(data.CursoCarrera t)
        {
            new EP.DAL.CursoCarrera(_solutionDBContext).Delete(t);
        }

        public IEnumerable<data.CursoCarrera> GetAll()
        {
            return new EP.DAL.CursoCarrera(_solutionDBContext).GetAll();
        }

        public data.CursoCarrera GetOneById(int id)
        {
            return new EP.DAL.CursoCarrera(_solutionDBContext).GetOneById(id);
        }

        public void Insert(data.CursoCarrera t)
        {
            new EP.DAL.CursoCarrera(_solutionDBContext).Insert(t);
        }

        public void Update(data.CursoCarrera t)
        {
            new EP.DAL.CursoCarrera(_solutionDBContext).Update(t);
        }
    }
}
