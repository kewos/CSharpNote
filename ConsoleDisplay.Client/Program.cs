using System;
using ConsoleDisplay.Data;
using Microsoft.Practices.Unity;
using System.Linq;
using System.Reflection;

namespace ConsoleDisplay.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();
            container.RegisterType<IMethodRepositoryFactory, MethodRepositoryFactory>();
            container.RegisterType<IProjectManager, ProjectManager>();
            container.RegisterType<IMethodManager, MethodManager>();

            var projectManager = container.Resolve<IProjectManager>();
            projectManager.Display();
        }
    }
}

