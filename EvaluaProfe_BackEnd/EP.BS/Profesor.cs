using EP.DAL.EF;
using EP.DO.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using data = EP.DO.Objects;

namespace EP.BS
{
    public class Profesor : ICRUD<data.Profesor>
    {
        private SolutionDBContext _solutionDBContext = null;

        public Profesor(SolutionDBContext solutionDBContext)
        {
            _solutionDBContext = solutionDBContext;
        }

        public void Delete(data.Profesor t)
        {
            new EP.DAL.Profesor(_solutionDBContext).Delete(t);
        }

        public IEnumerable<data.Profesor> GetAll()
        {
            return new EP.DAL.Profesor(_solutionDBContext).GetAll();
        }

        public data.Profesor GetOneById(int id)
        {
            return new EP.DAL.Profesor(_solutionDBContext).GetOneById(id);
        }

        public void Insert(data.Profesor t)
        {
            new EP.DAL.Profesor(_solutionDBContext).Insert(t);
        }

        public void Update(data.Profesor t)
        {
            new EP.DAL.Profesor(_solutionDBContext).Update(t);
        }
    }
}
