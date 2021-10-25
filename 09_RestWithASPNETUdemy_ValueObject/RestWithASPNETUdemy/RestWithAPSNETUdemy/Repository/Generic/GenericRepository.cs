using Microsoft.EntityFrameworkCore;
using RestWithAPSNETUdemy.Model.Base;
using RestWithAPSNETUdemy.Model.Context;
using RestWithASPNETUdemy.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithAPSNETUdemy.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MySqlContext _context;
        private readonly DbSet<T> dataset;
        public GenericRepository(MySqlContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }

        public T Create(T item)
        {
            try
            {
                item.DT_Criacao = DateTime.Now;
                dataset.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<T> FindAll()
        {
            return dataset.ToList();
        }

        public T FindById(long id)
        {
            return dataset.Find(id);
        }

        public T Update(T item)
        {
            var itemDb = dataset.Where(x => x.Equals(item)).FirstOrDefault();

            if (item != null)
            {
                try
                {
                    _context.Entry(itemDb).CurrentValues.SetValues(item);
                    itemDb.DT_Edicao = DateTime.Now;
                    _context.SaveChanges();
                    return itemDb;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else { return null;}
        }

        public void Delete(long id)
        {
            var item = dataset.Find(id);

            if (item != null)
            {
                try
                {
                    dataset.Remove(item);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Exists(long id)
        {
            return dataset.Find(id) != null;
        }
    }
}
