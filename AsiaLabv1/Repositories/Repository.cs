using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AsiaLabv1.Repositories
{
    public class Repository<T> where T : class
    {

        protected static AsiaLabdb2Entities Context;
        public DbSet<T> Table { get; set; }

        public Repository()
        {
            if (Context == null)
            {
                Context = StaticDbContext.context;
            }
            Table = Context.Set<T>();
        }

        public List<T> GetAll()
        {
            return Table.ToList();
        }
        public T GetById(int Id)
        {
            return Table.Find(Id);
        }

        public T Insert(T entity)
        {

            Table.Add(entity);
            Context.SaveChanges();
            return entity;
        }

        public void Update(T entity)
        {
            Table.Remove(entity);
            Table.Add(entity);
        }

        public void Delete(T entity)
        {
            Table.Remove(entity);
            Context.SaveChanges();
        }
        public void DeleteById(int Id)
        {
            var entity = GetById(Id);
            Table.Remove(entity);
            Context.SaveChanges();
        }

        public void DeleteAll()
        {
            var list = GetAll();

            foreach (var item in list)
            {
                Delete(item);
                Context.SaveChanges();
            }

        }
    }
}