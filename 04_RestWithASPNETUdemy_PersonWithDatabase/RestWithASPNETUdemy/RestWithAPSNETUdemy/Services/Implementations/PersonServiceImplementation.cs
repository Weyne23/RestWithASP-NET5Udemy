using RestWithAPSNETUdemy.Model.Context;
using RestWithASPNETUdemy.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNETUdemy.Services.Implementations
{
    public class PersonServiceImplementation : IPersonServices
    {
        private MySqlContext _context;
        public PersonServiceImplementation(MySqlContext context)
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
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public Person Update(Person person)
        {
            if (!Exists(person.CD_pessoa)) return new Person();
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

        private bool Exists(long id)
        {
            return _context.Persons.Any(x => x.CD_pessoa.Equals(id));
        }
    }
}
