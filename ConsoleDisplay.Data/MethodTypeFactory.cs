using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleDisplay.Core.Contracts;
using ConsoleDisplay.Data.AlgorithmMethod;
using ConsoleDisplay.Data.CSharpPracticeMethod;
using ConsoleDisplay.Data.DesignPattern;

namespace ConsoleDisplay.Data
{
    public interface IMethodTypeFactory
    {
        IEnumerable<Type> GetType();
    }

    public class MethodTypeFactory : IMethodTypeFactory
    {
        IEnumerable<Type> GetType
        {
            get
            {
                return new List<IMethodRepository>
                {
                    new AlgorithmMethod(),
                    new CSharpPracticeMethod(),
                    new DesignPattern(),
                };
            }
        }
    }
}
