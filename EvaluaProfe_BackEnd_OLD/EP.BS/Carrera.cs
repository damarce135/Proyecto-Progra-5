using EP.DAL.EF;
using EP.DO.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = EP.DO.Objects;

namespace EP.BS
{
    public class Carrera : ICRUD<data.Carrera>
    {
        private SolutionDBContext _solutionDBContext = null;

        public Carrera(SolutionDBContext solutionDBContext)
        {
            _solutionDBContext = solutionDBContext;
        }

        public void Delete(data.Carrera t)
        {
            new EP.DAL.Carrera(_solutionDBContext).Delete(t);
        }

        public IEnumerable<data.Carrera> GetAll()
        {
            return new EP.DAL.Carrera(_solutionDBContext).GetAll();
        }

        public data.Carrera GetOneById(int id)
        {
            return new EP.DAL.Carrera(_solutionDBContext).GetOneById(id);
        }

        public void Insert(data.Carrera t)
        {
            new EP.DAL.Carrera(_solutionDBContext).Insert(t);
        }

        public void Update(data.Carrera t)
        {
            new EP.DAL.Carrera(_solutionDBContext).Update(t);
        }
    }
}
