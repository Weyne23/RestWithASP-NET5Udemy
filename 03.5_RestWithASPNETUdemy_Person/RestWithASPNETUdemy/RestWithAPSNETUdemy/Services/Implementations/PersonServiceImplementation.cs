using RestWithASPNETUdemy.Model;
using System.Collections.Generic;
using System.Threading;

namespace RestWithASPNETUdemy.Services.Implementations
{
    public class PersonServiceImplementation : IPersonServices
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {

        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();

            for (int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }
            return persons;
        }

        public Person FindById(long id)
        {
            return new Person()
            {
                CD_pessoa = IncrementAddGet(),
                CH_address = "Rua Euripedes Ferreira Gomes",
                CH_firstName = "José",
                CH_lastName = "Maria",
                CH_gender = "Masculina"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }

        private Person MockPerson(int i)
        {
            return new Person()
            {
                CD_pessoa = IncrementAddGet(),
                CH_address = "Some Address " + i,
                CH_firstName = "Person Name " + i,
                CH_lastName = "Person LastName " + i,
                CH_gender = "Male " + i
            };
        }

        private long IncrementAddGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
