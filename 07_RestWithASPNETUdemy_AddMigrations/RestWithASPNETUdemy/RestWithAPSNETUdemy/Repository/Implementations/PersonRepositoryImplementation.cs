using RestWithAPSNETUdemy.Model.Context;
using RestWithASPNETUdemy.Model;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNETUdemy.Repository.Implementations
{
    public class PersonRepositoryImplementation : IPersonRepository
    {
        private readonly MySqlContext _context;
        public PersonRepositoryImplementation(MySqlContext context)
        {
            _context = context;
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person FindById(long id)
        {
            return _context.Persons.Find(id);
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
                return person;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(long id)
        {
            var pessoa = _context.Persons.Find(id);

            if (pessoa != null)
            {
                try
                {
                    _context.Persons.Remove(pessoa);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Log.Logger.Error(ex.Message);
                    throw;
                }
            }
        }

        public Person Update(Person person)
        {
            if (!Exists(person.CD_pessoa)) return null;
            var pessoa = _context.Persons.FirstOrDefault(x => x.CD_pessoa == person.CD_pessoa);

            if (pessoa != null)
            {
                try
                {
                    _context.Entry(pessoa).CurrentValues.SetValues(person);

                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return pessoa;
        }

        public bool Exists(long id)
        {
            return _context.Persons.Any(x => x.CD_pessoa.Equals(id));
        }
    }
}
