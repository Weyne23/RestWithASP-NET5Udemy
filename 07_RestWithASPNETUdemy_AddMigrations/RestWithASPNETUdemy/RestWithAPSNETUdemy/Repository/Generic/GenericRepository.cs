using Microsoft.EntityFrameworkCore;
using RestWithAPSNETUdemy.Model.Base;
using RestWithAPSNETUdemy.Model.Context;
using RestWithASPNETUdemy.Repository;
using System;
using System.Collections.Generic;

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
                dataset.Add(item);
                _context.SaveChanges(); 
            }
            catch (Exception)
            {
                throw;
            }

            return item;
        }

        public void Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public bool Exists(long id)
        {
            throw new System.NotImplementedException();
        }

        public List<T> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public T FindById(long id)
        {
            throw new System.NotImplementedException();
        }

        public T Update(T item)
        {
            throw new System.NotImplementedException();
        }
    }
}
