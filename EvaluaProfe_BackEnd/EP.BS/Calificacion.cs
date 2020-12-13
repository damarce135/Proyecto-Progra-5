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
    public class Calificacion : ICRUD<data.Calificacion>
    {
        private SolutionDBContext _repo = null;
        public Calificacion(SolutionDBContext solutionDBContext)
        {
            _repo = solutionDBContext;
        }
        public void Delete(data.Calificacion t)
        {
            new DAL.Calificacion(_repo).Delete(t);
        }

        public IEnumerable<data.Calificacion> GetAll()
        {
            return new DAL.Calificacion(_repo).GetAll();
        }

        public data.Calificacion GetOneById(int id)
        {
            return new DAL.Calificacion(_repo).GetOneById(id);
        }
        public async Task<IEnumerable<data.Calificacion>> GetAllInclude()
        {
            return await new DAL.Calificacion(_repo).GetAllInclude();
        }

        public async Task<data.Calificacion> GetOneByIdInclude(int id)
        {
            return await new DAL.Calificacion(_repo).GetOneByIdInclude(id);
        }

        public void Insert(data.Calificacion t)
        {
            new DAL.Calificacion(_repo).Insert(t);
        }

        public void Update(data.Calificacion t)
        {
            new DAL.Calificacion(_repo).Update(t);
        }
    }
}
