using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Contracts;

namespace CSharpNote.Core.Implements
{
    public abstract class AbstractRepository : ContextBoundObject, IMethodRepository
    {
        private const string TRIMSTRING = "Repository";
        private List<TypeInfo> methodInfos;
        private readonly Dictionary<int, AbstractExecuteModule> entitiyDictionary = new Dictionary<int, AbstractExecuteModule>(); 

        #region private member
        private IEnumerable<TypeInfo> MethodInfos
        {
            get
            {
                return methodInfos ?? 
                    (methodInfos = Assembly.GetAssembly(GetType())
                    .DefinedTypes
                    .Where(type => typeof(AbstractExecuteModule).IsAssignableFrom(type))
                    .ToList());
            }
        }
        #endregion

        #region IMethodRepository member
        public int Count
        {
            get 
            { 
                return MethodInfos.Count(); 
            }
        }

        public AbstractExecuteModule this[int index]
        {
            get
            {
                if (!entitiyDictionary.ContainsKey(index))
                {
                    index.ValidationBetweenRange(0, Count - 1);
                    var item = MethodInfos.Skip(index).FirstOrDefault();

                    entitiyDictionary.Add(index, Activator.CreateInstance(item) as AbstractExecuteModule);
                }

                return entitiyDictionary[index];
            }
        }

        public IEnumerable<string> GetMethodNames()
        {
            return MethodInfos.Select(item => item.Name);
        }

        public string RepositoryName
        {
            get
            {
                return GetType().Name.Except(TRIMSTRING);
            }
        }
        #endregion
    }
}