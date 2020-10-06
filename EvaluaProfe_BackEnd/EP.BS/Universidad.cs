using EP.DAL.EF;
using EP.DO.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using data = EP.DO.Objects;

namespace EP.BS
{
    public class Universidad : ICRUD<data.Universidad>
    {
        private SolutionDBContext _solutionDBContext = null; 

        public Universidad(SolutionDBContext solutionDBContext)
        {
            _solutionDBContext = solutionDBContext; 
        }

        public void Delete(data.Universidad t)
        {
            new EP.DAL.Universidad(_solutionDBContext).Delete(t);    
        }

        public IEnumerable<data.Universidad> GetAll()
        {
            return new EP.DAL.Universidad(_solutionDBContext).GetAll();
        }

        public data.Universidad GetOneById(int id)
        {
            return new EP.DAL.Universidad(_solutionDBContext).GetOneById(id); 
        }

        public void Insert(data.Universidad t)
        {
            new EP.DAL.Universidad(_solutionDBContext).Insert(t);
        }

        public void Update(data.Universidad t)
        {
            new EP.DAL.Universidad(_solutionDBContext).Update(t);
        }
    }
}
