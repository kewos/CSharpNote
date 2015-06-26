using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharpNote.Data.DesignPatternMethod.SubClass.StretagyPattern
{
    public class Strategy
    {
        private readonly Dictionary<string, Func<int>> strategies;

        public Strategy()
        {
            //透過反射可符合close open principle
            strategies = GetType().GetMethods
                (
                    BindingFlags.NonPublic 
                    | BindingFlags.Instance 
                    | BindingFlags.DeclaredOnly
                )
                .Where(method =>
                    //Arguments Null
                    !method.GetGenericArguments().Any()
                    //Return Int
                    && method.ReturnType == typeof(int))
                .ToDictionary(
                    method => method.Name,
                    method => 
                    {
                        return (Func<int>)Delegate.CreateDelegate
                        (
                            Expression.GetDelegateType
                            (
                                method.GetParameters()
                                    .Select(p => p.ParameterType)
                                    .Concat(new Type[] { method.ReturnType })
                                    .ToArray()
                            ),
                            null,
                            method
                        );   
                    });
        }

        public Func<int> this[string key]
        {
            get
            {
                if (strategies == null || !strategies.Any())
                {
                    return null;
                }

                Func<int> value;
                return strategies.TryGetValue(key, out value) ? value : null;
            }
        }

        private int Strategy001()
        {
            //your code
            return 001;
        }

        private int Strategy002()
        {
            //your code
            return 002;
        }

        private int Strategy003()
        {
            //your code
            return 003;
        }
    }
}
