using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CSharpNote.Core.Contracts;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;

namespace CSharpNote.Core.Implements
{
    public abstract class AbstractMethodRepository : ContextBoundObject, IMethodRepository
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
                return TrimString(GetType().Name);
            }
        }
        #endregion

        #region private member
        private IEnumerable<MethodInfo> MethodInfos
        {
            get
            {
                if (methodInfos == null)
                {
                    methodInfos = GetType()
                        .GetMethods(BindingFlags.Public | BindingFlags.Instance)
                        .Where(method => method.GetCustomAttribute(typeof (MarkedItemAttribute), false) != null)
                        .OrderBy(method => method.Name);
                }

                return methodInfos;
            }
        }

        private string TrimString(string str)
        {
            str.ValidationEndWith(TRIMSTRING);

            var start = 0;
            var end = str.Length - TRIMSTRING.Length;

            return str.Substring(start, end);
        }
        #endregion
    }
}
