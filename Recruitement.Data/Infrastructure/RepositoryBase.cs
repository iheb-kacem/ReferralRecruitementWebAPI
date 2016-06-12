using Recruitement.Data.Contracts;
using Recruitement.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;

namespace Recruitement.Data.Infrastructure
{
    abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        protected RecruitementContext dataContext = null;
        protected IDatabaseFactory db = null;
        protected DbSet<T> dbset = null;
        public RepositoryBase(IDatabaseFactory db)
        {
            this.db = db;
            dbset = DataContext.Set<T>();
        }

        public RecruitementContext DataContext
        {

            get { return dataContext = db.DataContext; }

        }


        public virtual void Add(T entity)
        {
            var entry = dataContext.Entry(entity);
            if (entry != null)
            {
                entry.State = EntityState.Added;
            }
        }

        public virtual void Update(T entity)
        {
            dbset.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(int Id)
        {
            T entity = dbset.Find(Id);
            dbset.Remove(entity);
        }

        public virtual void Delete(System.Linq.Expressions.Expression<Func<T, bool>> where)
        {
            dbset.RemoveRange(dbset.Where(where).AsEnumerable());
        }

        public virtual T Get(System.Linq.Expressions.Expression<Func<T, bool>> where)
        {
            return dbset.Where(where).FirstOrDefault();
        }

        public virtual T GetById(string Id)
        {
            return dbset.Find(Id);
        }

        public virtual T GetById(long Id)
        {
            return dbset.Find(Id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbset.AsEnumerable();
        }

        public virtual IEnumerable<T> GetMany(System.Linq.Expressions.Expression<Func<T, bool>> where)
        {
            return dbset.Where(where).AsEnumerable();
        }


    }
}
