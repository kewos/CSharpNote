using System.Collections.Generic;
using System.Linq;

namespace ConsoleDisplay.Data.DesignPatternMethod.SubClass
{
    public class PersonRepository : IPersonRepository
    {
        public IEnumerable<Person> GetPeople()
        {
            using (var context = new FakeDbContext())
            {
                return context.GetDbSet<Person>();
            }
        }

        public Person GetPerson(string lastName)
        {
            using (var context = new FakeDbContext())
            {
                return context.GetDbSet<Person>().Where(p => p.LastName == lastName).FirstOrDefault();
            }
        }

        public void AddPerson(Person newPerson)
        {
            using (var context = new FakeDbContext())
            {
                context.GetDbSet<Person>().Add(newPerson);
                context.SaveChanges();
            }
        }

        public void UpdatePerson(string lastName, Person updatedPerson)
        {
            using (var context = new FakeDbContext())
            {
                var person = context.GetDbSet<Person>().Where(p => p.LastName == lastName).FirstOrDefault();
                {
                    person.LastName = updatedPerson.LastName;
                    person.FirstName = updatedPerson.FirstName;
                }
                context.SaveChanges();
            }
        }

        public void DeletePerson(string lastName)
        {
            using (var context = new FakeDbContext())
            {
                var person = context.GetDbSet<Person>().Where(p => p.LastName == lastName).FirstOrDefault();
                context.GetDbSet<Person>().Remove(person);
                context.SaveChanges();
            }
        }
    }
}