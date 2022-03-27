using Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ApplicationContext context;
        protected RepositoryBase(ApplicationContext context)
        {
            this.context = context;
        }
        public void Create(T entity)
        {
            context.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindByCondition(System.Linq.Expressions.Expression<Func<T, bool>> expression, bool trackChanges)
        {
            if (!trackChanges)
                return context.Set<T>().Where(expression).AsNoTracking();
            else
                return context.Set<T>().Where(expression);
        }

        public IQueryable<T> GetAll(bool trackChanges)
        {
            if (!trackChanges)
                return context.Set<T>().AsNoTracking();
            else
                return context.Set<T>();
        }

    }
}
