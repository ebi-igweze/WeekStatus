using System;
using System.Linq;
using System.Linq.Expressions;
using DBModels;
using Microsoft.EntityFrameworkCore;

namespace Repository 
{
    public interface IRepository<T> where T : BaseModel 
    {
        T GetSingle(int Id);
        IQueryable<T> GetAll();
        void Add(T entity);
        void Edit(T entity);
        void Delete(int id);
        IQueryable<T> FindBy(Expression<Func<T,bool>> filter);
        void SaveChanges();
    }

    public class BlogRepository<U,T>: IRepository<T> where U: DbContext where T: BaseModel 
    {
        private readonly U db;

        public BlogRepository(U db) {
            this.db = db;
        }

        public void Add(T entity)
        {
            this.db.Set<T>().Add(entity);
        }

        public void Delete(int id)
        {
            var entity = GetSingle(id);
            this.db.Set<T>().Remove(entity);
        }

        public void Edit(T entity)
        {
            this.db.Set<T>().Update(entity);
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> filter)
        {
            return this.db.Set<T>().Where(filter);
        }

        public IQueryable<T> GetAll()
        {
            return this.db.Set<T>();
        }

        public T GetSingle(int Id)
        {
            return this.db.Set<T>().Where(e => e.ID == Id).FirstOrDefault();
        }

        public void SaveChanges() => this.db.SaveChanges();
    }

}