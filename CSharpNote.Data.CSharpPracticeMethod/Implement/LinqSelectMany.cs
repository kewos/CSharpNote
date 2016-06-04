using System;
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.CSharpPractice.Implement
{
    public class LinqSelectMany : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            PetOwner[] petOwners =
            {
                new PetOwner
                {
                    Name = "Higa, Sidney",
                    Pets = new List<string> {"Scruffy", "Sam"}
                },
                new PetOwner
                {
                    Name = "Ashkenazi, Ronen",
                    Pets = new List<string> {"Walker", "Sugar"}
                },
                new PetOwner
                {
                    Name = "Price, Vernette",
                    Pets = new List<string> {"Scratches", "Diesel"}
                }
            };

            Console.WriteLine("Using SelectMany():");

            foreach (var pet in petOwners.SelectMany(petOwner => petOwner.Pets))
            {
                Console.WriteLine(pet);
            }

            Console.WriteLine("\nUsing Select():");

            foreach (var petList in petOwners.Select(petOwner => petOwner.Pets))
            {
                foreach (var pet in petList)
                {
                    Console.WriteLine(pet);
                }
                Console.WriteLine();
            }
        }

        private class PetOwner
        {
            public string Name { get; set; }
            public List<string> Pets { get; set; }
        }
    }
}