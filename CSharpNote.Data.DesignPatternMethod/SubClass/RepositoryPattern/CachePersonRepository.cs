using System;
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Extendsions;

namespace CSharpNote.Data.DesignPatternMethod.SubClass.RepositoryPattern
{
    public class CachePersonRepository : IPersonRepository
    {
        private readonly TimeSpan cacheDuration = TimeSpan.FromSeconds(30);
        private DateTime lastUpdateDateTime;
        private readonly IPersonRepository personRepository;
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
                return (DateTimeOffset.Now - lastUpdateDateTime) < cacheDuration;
            }
        }

        private void ValidateCache()
        {
            if (cacheItems != null || IsCacheValid) return;
            try
            {
                cacheItems = personRepository.GetPeople();
                lastUpdateDateTime = DateTime.Now;
            }
            catch  
            {
                cacheItems = new List<Person>()
                {
                    new Person { FirstName="No Data Available", LastName = "No Data Available"},
                };
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
