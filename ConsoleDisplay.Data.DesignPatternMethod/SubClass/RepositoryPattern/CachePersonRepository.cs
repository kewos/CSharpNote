using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDisplay.Data.DesignPatternMethod.SubClass
{
    public class CachePersonRepository : IPersonRepository
    {
        private TimeSpan cacheDuration = TimeSpan.FromSeconds(30);
        private DateTime dataDateTime;
        private IPersonRepository personRepository;
        private IEnumerable<Person> cacheItems;

        /// <summary>
        /// Decorator Pattern operate object dynamically via Dependecy Injection
        /// </summary>
        public CachePersonRepository(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        private bool IsCacheValid
        {
            get
            {
                return (DateTimeOffset.Now - dataDateTime) < cacheDuration;
            }
        }

        private void ValidateCache()
        {
            if (cacheItems == null || !IsCacheValid)
            {
                try
                {
                    cacheItems = personRepository.GetPeople();
                    dataDateTime = DateTime.Now;
                }
                catch  
                {
                    cacheItems = new List<Person>()
                    {
                        new Person{ FirstName="No Data Available", LastName = "No Data Available"},
                    };
                }
            }
        }

        private void InvalidateCache()
        {
            "Cache清空".ToConsole();
            cacheItems = null; 
        }

        public IEnumerable<Person> GetPeople()
        {
            ValidateCache();
            "GetObjectFromCache".ToConsole();
            return cacheItems; 
        }

        public Person GetPerson(string lastName)
        {
            ValidateCache();
            "GetObjectFromCache".ToConsole();
            return cacheItems.FirstOrDefault(p => p.LastName.Equals(lastName)); 
        }

        public void AddPerson(Person newPerson)
        {
            personRepository.AddPerson(newPerson);
            InvalidateCache();
        }

        public void UpdatePerson(string lastName, Person updatedPerson)
        {
            personRepository.UpdatePerson(lastName, updatedPerson);
            InvalidateCache();
        }

        public void DeletePerson(string lastName)
        {
            personRepository.DeletePerson(lastName);
            InvalidateCache();
        }
    }
}
