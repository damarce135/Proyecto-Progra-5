using EP.DAL.EF;
using EP.DO.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using data = EP.DO.Objects;

namespace EP.BS
{
    public class ProfCurso : ICRUD<data.ProfCurso>
    {
        private SolutionDBContext _solutionDBContext = null;

        public ProfCurso(SolutionDBContext solutionDBContext)
        {
            _solutionDBContext = solutionDBContext;
        }

        public void Delete(data.ProfCurso t)
        {
            new EP.DAL.ProfCurso(_solutionDBContext).Delete(t);
        }

        public IEnumerable<data.ProfCurso> GetAll()
        {
            return new EP.DAL.ProfCurso(_solutionDBContext).GetAll();
        }

        public data.ProfCurso GetOneById(int id)
        {
            return new EP.DAL.ProfCurso(_solutionDBContext).GetOneById(id);
        }

        public void Insert(data.ProfCurso t)
        {
            new EP.DAL.ProfCurso(_solutionDBContext).Insert(t);
        }

        public void Update(data.ProfCurso t)
        {
            new EP.DAL.ProfCurso(_solutionDBContext).Update(t);
        }
    }
}
