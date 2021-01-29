using RestWithASPNET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithASPNET.Services.Implementations
{
    public class PersonServicesImplementation : IPersonService
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
            var people = new List<Person>();
            for (int i = 1; i < 6; i++)
            {
                Person person = MockPerson(i);
                people.Add(person);
            }
            return people;
        }

        public Person FindById(long id)
        {
            return new Person 
            {
                Id = IncrementAndGet(),
                FirstName = "Lucas",
                LastName = "Krueger",
                Address = "Blumenau - SC - Brasil",
                Gender = "Male"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }
        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Person Name" + i,
                LastName = "Person LastName" + i,
                Address = "Some address" + i,
                Gender = "gender"
            };
        }

        private int IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
