using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CSharpNote.Core.Contracts;
using CSharpNote.Common.Attributes;

namespace CSharpNote.Core.Implements
{
    public abstract class AbstractMethodRepository : ContextBoundObject, IMethodRepository
    {
        private IList<MethodInfo> methodInfos;
        private const string TRIMSTRING = "MethodRepository";

        #region IMethodRepository member
        public int Count
        {
            get
            {
                return MethodInfos.Count;
            }
        }

        public MethodInfo this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException("IndexOutOfRangeException");
                }

                return MethodInfos[index];
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
                return TrimString(GetType().Name);
            }
        }
        #endregion

        #region private member
        private IList<MethodInfo> MethodInfos
        {
            get
            {
                if (methodInfos == null)
                {
                    methodInfos = GetType()
                        .GetMethods(BindingFlags.Public | BindingFlags.Instance)
                        .Where(method => method.GetCustomAttribute(typeof(MarkedItemAttribute), false) != null)
                        .OrderBy(method => method.Name)
                        .ToList();
                }

                return methodInfos;
            }
        }

        private string TrimString(string str)
        {
            if (!str.EndsWith(TRIMSTRING))
            {
                throw new ArgumentException("InvalidString");
            }
            var Start = 0;
            var End = str.Length - TRIMSTRING.Length;
            return str.Substring(Start, End);
        }
        #endregion
    }
}
