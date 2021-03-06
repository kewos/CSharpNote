﻿using System.Collections.Generic;

namespace CSharpNote.Data.DesignPattern.Implement.RepositoryPattern
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetPeople();
        Person GetPerson(string lastName);
        void AddPerson(Person newPerson);
        void UpdatePerson(string lastName, Person updatedPerson);
        void DeletePerson(string lastName);
    }
}