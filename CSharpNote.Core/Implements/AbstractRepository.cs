using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CSharpNote.Core.Contracts;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;

namespace CSharpNote.Core.Implements
{
    public abstract class AbstractRepository : ContextBoundObject, IMethodRepository
    {
        private IEnumerable<MethodInfo> methodInfos;
        private const string TRIMSTRING = "Repository";

        #region IMethodRepository member
        public int Count
        {
            get
            {
                return MethodInfos.Count();
            }
        }

        public MethodInfo this[int index]
        {
            get
            {
                index.ValidationBetweenRange(0, Count - 1);

                return MethodInfos.Skip(index).FirstOrDefault();
            }
        }

        public IEnumerable<string> GetMethodNames()
        {
            return MethodInfos.Select(methodInfo => methodInfo.Name);
        }

        public string RepositoryName
        {
            get
            {
                return GetType().Name.Except(TRIMSTRING);
            }
        }
        #endregion

        #region private member
        private IEnumerable<MethodInfo> MethodInfos
        {
            get
            {
                return methodInfos ?? (methodInfos = GetType()
                    .GetMethods(BindingFlags.Public | BindingFlags.Instance)
                    .Where(method => method.GetCustomAttribute(typeof (MarkedItemAttribute), false) != null)
                    .OrderBy(method => method.Name));
            }
        }
        #endregion
    }
}
