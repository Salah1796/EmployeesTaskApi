using Tayar.Achitecture.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tayar.Achitecture.Repositories;

namespace Tayar.Architecture.Repositories
{
    public class Generic<T> where T : BaseModel
    {
        private DbSet<T> dbSet;
        public EnitiesContext Context { get; set; }

        public Generic(EnitiesContext context)
        {
            Context = context;
            dbSet = Context.Set<T>();
        }
        public T Add(T T)
        {
            return dbSet.Add(T);
        }
        public T Update(T T)
        {
            if (!dbSet.Local.Any(i => i.ID == T.ID))
                dbSet.Attach(T);
            Context.Entry(T).State = EntityState.Modified;
            return T;
        }
        public void Remove(T T)
        {
            if (T != null)
            {
                T.IsDeleted = true;
                Context.Entry(T).State = EntityState.Modified;
            }
        }
        public T GetByID(int id)
        {
            return dbSet.Where(i => i.IsDeleted == false).FirstOrDefault(i => i.ID == id);
        }
        public IQueryable<T>GetAll(out int count, int PageIndex, int PageSize, string SortField, bool Ascending)
        {
            count = dbSet.Where(i => i.IsDeleted == false).Count();
            return dbSet.Where(i => i.IsDeleted == false).OrderByPropertyName(SortField, Ascending).Skip(PageIndex * PageSize).Take(PageSize);
        }
        public IQueryable<T> Get(Expression<Func<T, bool>> filter)
        {
            return dbSet.Where(filter);
        }
        public IQueryable<T> GetAll()
        {
            return dbSet.Where(i => i.IsDeleted == false);
        }

    }
}
