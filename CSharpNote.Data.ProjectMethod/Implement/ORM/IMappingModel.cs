using System;
using System.Collections.Generic;

namespace CSharpNote.Data.Project.Implement.ORM
{
    public interface IMappingModel
    {
        string Mapping(string source);
    }

    public abstract class MappingModelBase : IMappingModel
    {
        private readonly Dictionary<string, string> mappingDictionary;

        protected MappingModelBase()
        {
            mappingDictionary = new Dictionary<string, string>();
        }

        public string Mapping(string input)
        {
            return mappingDictionary.ContainsKey(input)
                ? mappingDictionary[input]
                : input;
        }

        public MappingModelBase SetMapping(string input, string output)
        {
            if (!mappingDictionary.ContainsKey(input))
            {
                mappingDictionary.Add(input, output);
                return this;
            }
            throw new Exception("Duplication Error");
        }
    }
}