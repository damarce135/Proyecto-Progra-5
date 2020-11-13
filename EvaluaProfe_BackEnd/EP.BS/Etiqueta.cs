using EP.DAL.EF;
using EP.DO.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using data = EP.DO.Objects;

namespace EP.BS
{
    public class Etiqueta : ICRUD<data.Etiqueta>
    {
        private SolutionDBContext _solutionDBContext = null; 

        public Etiqueta(SolutionDBContext solutionDBContext)
        {
            _solutionDBContext = solutionDBContext; 
        }

        public void Delete(data.Etiqueta t)
        {
            new EP.DAL.Etiqueta(_solutionDBContext).Delete(t);    
        }

        public IEnumerable<data.Etiqueta> GetAll()
        {
            return new EP.DAL.Etiqueta(_solutionDBContext).GetAll();
        }

        public data.Etiqueta GetOneById(int id)
        {
            return new EP.DAL.Etiqueta(_solutionDBContext).GetOneById(id); 
        }

        public void Insert(data.Etiqueta t)
        {
            new EP.DAL.Etiqueta(_solutionDBContext).Insert(t);
        }

        public void Update(data.Etiqueta t)
        {
            new EP.DAL.Etiqueta(_solutionDBContext).Update(t);
        }
    }
} 
