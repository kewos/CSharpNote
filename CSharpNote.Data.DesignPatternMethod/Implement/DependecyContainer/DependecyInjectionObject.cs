using CSharpNote.Common.Extensions;

namespace CSharpNote.Data.DesignPatternMethod.Implement.DependecyContainer
{
    public interface IDependencyInjectorA
    {
        void Do();
    }

    public interface IDependencyInjectorB
    {
        void Do();
    }

    public interface IInstanceA
    {
        void Do();
    }

    public interface IInstanceB
    {
        void Do();
    }

    public class InstanceA : IInstanceA
    {
        private readonly IDependencyInjectorA dependencyInjectorA;
        private readonly IDependencyInjectorB dependencyInjectorB;

        public InstanceA(IDependencyInjectorA dependencyInjectorA, IDependencyInjectorB dependencyInjectorB)
        {
            this.dependencyInjectorA = dependencyInjectorA;
            this.dependencyInjectorB = dependencyInjectorB;
        }

        public void Do()
        {
            "Im InstanceA My HashCode is".ToConsole("", GetHashCode().ToString());
            dependencyInjectorA.Do();
            dependencyInjectorB.Do();
        }
    }

    public class DependencyInjectorA : IDependencyInjectorA
    {
        public void Do()
        {
            "Im DependencyInjectorA in InstanceA My HashCode is".ToConsole("", GetHashCode().ToString());
        }
    }

    public class DependencyInjectorB : IDependencyInjectorB
    {
        public void Do()
        {
            "Im DependencyInjectorB in InstanceA My HashCode is".ToConsole("", GetHashCode().ToString());
        }
    }

    public class InstanceB : IInstanceB
    {
        private readonly IDependencyInjectorA dependencyInjectorA;
        private readonly IDependencyInjectorB dependencyInjectorB;

        public InstanceB(IDependencyInjectorA dependencyInjectorA, IDependencyInjectorB dependencyInjectorB)
        {
            this.dependencyInjectorA = dependencyInjectorA;
            this.dependencyInjectorB = dependencyInjectorB;
        }

        public void Do()
        {
            "Im InstanceB My HashCode is".ToConsole("", GetHashCode().ToString());
            dependencyInjectorA.Do();
            dependencyInjectorB.Do();
        }
    }
}