using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using ConsoleDisplay.Data.Contracts;

namespace ConsoleDisplay.Data
{
    public interface IMethodRepositoryFactory
    {
        Dictionary<Type, Type> MethodRepositoryTypes { get; set; }
    }
    public class MethodRepositoryFactory : IMethodRepositoryFactory
    {
        public Dictionary<Type, Type> MethodRepositoryTypes { get; set; }
        public MethodRepositoryFactory()
        {
            MethodRepositoryTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(@type => @type.IsClass 
                    && !@type.IsAbstract 
                    && !@type.IsInterface
                    && @type.GetInterfaces()
                        .Any(@interface => @interface == typeof(IMethodRepository)))
                .ToDictionary(
                    @type => @type.GetInterfaces()
                        .Where(@interface =>
                            @interface.Name.Substring(1, @interface.Name.Length - 1) == @type.Name)
                        .FirstOrDefault(), 
                    @type => @type);
        }
    }
}
