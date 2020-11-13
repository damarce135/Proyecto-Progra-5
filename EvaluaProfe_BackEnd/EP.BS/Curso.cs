using EP.DAL.EF;
using EP.DO.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using data = EP.DO.Objects;

namespace EP.BS
{
    public class Curso : ICRUD<data.Curso>
    {
        private SolutionDBContext _solutionDBContext = null;

        public Curso(SolutionDBContext solutionDBContext)
        {
            _solutionDBContext = solutionDBContext;
        }

        public void Delete(data.Curso t)
        {
            new EP.DAL.Curso(_solutionDBContext).Delete(t);
        }

        public IEnumerable<data.Curso> GetAll()
        {
            return new EP.DAL.Curso(_solutionDBContext).GetAll();
        }

        public data.Curso GetOneById(int id)
        {
            return new EP.DAL.Curso(_solutionDBContext).GetOneById(id);
        }

        public void Insert(data.Curso t)
        {
            new EP.DAL.Curso(_solutionDBContext).Insert(t);
        }

        public void Update(data.Curso t)
        {
            new EP.DAL.Curso(_solutionDBContext).Update(t);
        }
    }
}
