using EP.DAL.EF;
using EP.DO.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using data = EP.DO.Objects;

namespace EP.BS
{
    public class ProfUniversidad : ICRUD<data.ProfUniversidad>
    {
        private SolutionDBContext _solutionDBContext = null;

        public ProfUniversidad(SolutionDBContext solutionDBContext)
        {
            _solutionDBContext = solutionDBContext;
        }

        public void Delete(data.ProfUniversidad t)
        {
            new EP.DAL.ProfUniversidad(_solutionDBContext).Delete(t);
        }

        public IEnumerable<data.ProfUniversidad> GetAll()
        {
            return new EP.DAL.ProfUniversidad(_solutionDBContext).GetAll();
        }

        public data.ProfUniversidad GetOneById(int id)
        {
            return new EP.DAL.ProfUniversidad(_solutionDBContext).GetOneById(id);
        }

        public void Insert(data.ProfUniversidad t)
        {
            new EP.DAL.ProfUniversidad(_solutionDBContext).Insert(t);
        }

        public void Update(data.ProfUniversidad t)
        {
            new EP.DAL.ProfUniversidad(_solutionDBContext).Update(t);
        }
    }
}
