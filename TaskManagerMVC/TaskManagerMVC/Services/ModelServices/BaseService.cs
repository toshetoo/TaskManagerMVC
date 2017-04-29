using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TaskManagerMVC.Models;

namespace TaskManagerMVC.Services.ModelServices
{
    public abstract class BaseService<T> where T : BaseModel
    {
        private TaskManagerContext context;
        private DbSet<T> dbSet;

        public BaseService()
        {
            this.context = new TaskManagerContext();
            this.dbSet = context.Set<T>();
        }

        public T GetById(int id)
        {
            return this.dbSet.Find(id);
        }

        public List<T> GetAll()
        {
            return this.dbSet.ToList();
        }

        public void Insert(T item)
        {
            this.dbSet.Add(item);
            this.context.SaveChanges();
        }

        public void Update(T item)
        {
            this.context.Entry(item).State = EntityState.Modified;
            this.context.SaveChanges();
        }

        public void Delete(int id)
        {
            this.dbSet.Remove(GetById(id));
            this.context.SaveChanges();
        }
    }
}