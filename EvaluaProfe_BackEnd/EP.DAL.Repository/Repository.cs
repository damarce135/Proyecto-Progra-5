using EP.DAL.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EP.DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly SolutionDBContext dbContext;

        public Repository(SolutionDBContext context)
        {
            dbContext = context;
        }

        public void AddRange(IEnumerable<T> entities)
        {
            dbContext.Set<T>().AddRange(entities);
        }

        public IQueryable<T> AsQueryable()
        {
            return dbContext.Set<T>().AsQueryable();
        }

        public void Commit()
        {
            dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            try
            {
                dbContext.Entry<T>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            }
            catch (Exception ee)
            {
            }
        }

        public IEnumerable<T> GetAll()
        {
            return dbContext.Set<T>();
        }

        public T GetOne(Expression<Func<T, bool>> predicado)
        {
            return dbContext.Set<T>().Where(predicado).FirstOrDefault();
        }

        public T GetOneById(int id)
        {
            return dbContext.Set<T>().Find(id);
        }

        public void Insert(T entity)
        {
            if (dbContext.Entry<T>(entity).State == EntityState.Detached)
            {
                dbContext.Entry<T>(entity).State = EntityState.Added;
            }
            else
            {
                dbContext.Set<T>().Add(entity);
            }
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbContext.Set<T>().RemoveRange(entities);
        }

        public IEnumerable<T> Search(Expression<Func<T, bool>> predicado)
        {
            return dbContext.Set<T>().Where(predicado);
        }

        public void Update(T entity)
        {
            if (dbContext.Entry<T>(entity).State == EntityState.Detached)
            {
                dbContext.Set<T>().Attach(entity);
            }
            dbContext.Entry<T>(entity).State = EntityState.Modified;
        }

    }
}
