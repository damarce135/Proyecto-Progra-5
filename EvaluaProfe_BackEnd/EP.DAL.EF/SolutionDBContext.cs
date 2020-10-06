using EP.DO.Objects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EP.DAL.EF
{
    public class SolutionDBContext:DbContext 
    {
        public SolutionDBContext(DbContextOptions<SolutionDBContext> options) 
            :base(options) 
        {

        }

        public DbSet<Universidad> Universidades { get; set; }
        
    }
}
