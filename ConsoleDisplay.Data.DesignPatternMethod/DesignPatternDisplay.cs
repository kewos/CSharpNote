using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.Xml.Linq;
using ConsoleDisplay.Data.DesignPatternMethod.SubClass;
using ConsoleDisplay.Common;
using ConsoleDisplay.Core.Contracts;
using ConsoleDisplay.Core.Implements;

namespace ConsoleDisplay.Data.DesignPatternMethod
{
    [DisplayClassAttribue]
    public class DesignPatternMethodRepository : AbstractMethodRepository
    {
        [DisplayMethod]
        public void CommandPattern()
        {
            // Create receiver, command, and invoker 
            Receiver receiver = new Receiver(20, 10);
            Invoker invoker = new Invoker();

            // Set and execute command 
            invoker.SetCommand(new AddCommond(receiver));
            invoker.SetCommand(new SubtractCommond(receiver));
            invoker.SetCommand(new MultiplicateCommond(receiver));
            invoker.ExecuteCommand();

            // Wait for user 
            Console.Read();
        }

        [DisplayMethod]
        public void ObserverPattern()
        {
            ISubject bloger = new Bloger();
            bloger.Regist(new Man("A"));
            bloger.Regist(new Woman("B"));
            bloger.NotifyObserver("abc test");
        }

        [DisplayMethod]
        public void VistorPattern()
        {
            BuffetDinner b = new BuffetDinner();
            b.Attach(new Coffee());
            b.Attach(new Vegetable());
            b.Attach(new Meat());

            ZhangSan z = new ZhangSan();
            LiSi l = new LiSi();

            b.Accept(z);
            Console.WriteLine("----------------------");
            b.Accept(l);
        }

        [DisplayMethod]
        public void NullObjectPattern()
        {
            PeopleRespository p = new PeopleRespository();
            Console.WriteLine(p.Find("123").Speak);
            Console.WriteLine(p.Find("1").Speak);
            Console.WriteLine(p.Find("2").Speak);
            Console.WriteLine(p.Find("3").Speak);
            Console.WriteLine(p.Find("4").Speak);

            Console.ReadLine();
        }

        [DisplayMethod]
        public void StatetPattern()
        {
            Player player = new Player();
            player.Level = 10;
            player.DoWork();
            player.Level = 20;
            player.DoWork();
            player.Level = 40;
            player.DoWork();
            player.Level = 90;
            player.DoWork();
        }

        [DisplayMethod]
        public void ChainResponsibilityPattern()
        {
            Chain chainA = new ChainA();
            Chain chainB = new ChainB();
            Chain chainC = new ChainC();
            Chain chainD = new ChainD();

            chainA.setUpChain(chainB);
            chainB.setUpChain(chainC);
            chainC.setUpChain(chainD);

            chainA.RequestChain(1);
            chainA.RequestChain(3);
            chainA.RequestChain(5);
            chainA.RequestChain(10);
        }

        [DisplayMethod]
        public void PipelinePattern()
        {
            //IWorkLine workLine = new WorkLine(new Factory());
            //workLine.Execute();
        }

        [DisplayMethod]
        public void BridgePattern()
        {
            // Create RefinedAbstraction
            CustomersBusinessObject customers =
              new CustomersBusinessObject(" Chicago ");

            // Set ConcreteImplementor
            customers.DataObject = new CustomersDataObject();

            // Exercise the bridge
            customers.Show();
            customers.Next();
            customers.Show();
            customers.Next();
            customers.Show();
            customers.New("Henry Velasquez");

            customers.ShowAll();
        }

        [DisplayMethod]
        public void AspectOrientProgram()
        {
            AOP.Registry.Join(
                    typeof(Actor).GetConstructors().First(), 
                    typeof(Concern).GetConstructors().First()
                );
            var actor = (IActor)AOP.Factory.Create<Actor>("");

            Console.WriteLine(actor.Name);
            Console.WriteLine(new Actor("adabcbc").Name);
        }

        [DisplayMethod]
        public void PrototypePattern()
        {
            ColorManager colormanager = new ColorManager();

            // Initialize with standard colors
            colormanager["red"] = new Color(255, 0, 0);
            colormanager["green"] = new Color(0, 255, 0);
            colormanager["blue"] = new Color(0, 0, 255);

            // User adds personalized colors
            colormanager["angry"] = new Color(255, 54, 0);
            colormanager["peace"] = new Color(128, 211, 128);
            colormanager["flame"] = new Color(211, 34, 20);

            // User uses selected colors
            string colorName = "red";
            Color c1 = (Color)colormanager[colorName].Clone();
            c1.Display();

            colorName = "peace";
            Color c2 = (Color)colormanager[colorName].Clone();
            c2.Display();

            colorName = "flame";
            Color c3 = (Color)colormanager[colorName].Clone();
            c3.Display();
        }

        [DisplayMethod]
        public void CompositePattern()
        {
            (new Manager()
            {
                supervisors = new List<IStuff>()
                {
                    new Supervisor()
                    {
                        workers = new List<IStuff>()
                        {
                            new Worker(),
                            new Worker(),
                            new Worker()
                        }
                    },
                    new Supervisor()
                    {
                        workers = new List<IStuff>()
                        {
                            new Worker(),
                        }
                    },
                    new Supervisor()
                    {
                        workers = new List<IStuff>()
                        {
                            new Worker(),
                            new Worker()
                        }
                    }
                }
            }).Opertaion();
        }

        [DisplayMethod(
            "http://www.codeproject.com/Articles/670115/Specification-pattern-in-Csharp", 
            "http://en.wikipedia.org/wiki/Specification_pattern#mediaviewer/File:Specification_UML_v2.png")]
        public void SpecificationPattern()
        {
            var bands = new List<Band>
            {
                new Band("AC/DC", BandKind.HardCore, Country.Australia),
                new Band("Rammstein", BandKind.IndustryMetal, Country.Gereman),
                new Band("PinkFloyd", BandKind.ClassRock, Country.UK),
                new Band("TheVerve", BandKind.BritPop, Country.UK),
                new Band("Nirvana", BandKind.Grunge, Country.UK),
                new Band("Queen", BandKind.ClassRock, Country.UK),
                new Band("SexPistals", BandKind.Punk, Country.UK),
            };

            ISpecification<Band> ukExpSpec =
               new ExpressionSpecification<Band>(band => band.Country == Country.UK);
            ISpecification<Band> australiaExpSpec =
               new ExpressionSpecification<Band>(band => band.Country == Country.Australia);
            ISpecification<Band> germanExpSpec =
               new ExpressionSpecification<Band>(band => band.Country == Country.Gereman);
   
            ISpecification<Band> britPopExpSpec =
               new ExpressionSpecification<Band>(band => band.BandKind == BandKind.BritPop);
            ISpecification<Band> classRockExpSpec =
               new ExpressionSpecification<Band>(band => band.BandKind == BandKind.ClassRock);

            Console.WriteLine("================Search:UK Band");
            bands.FindAll(band => ukExpSpec.IsSatisfiedBy(band))
                .ForEach(band => band.Description());

            Console.WriteLine("================Search:Australia Band");
            bands.FindAll(band => australiaExpSpec.IsSatisfiedBy(band))
                .ForEach(band => band.Description());

            Console.WriteLine("================Search:Gereman Band");
            bands.FindAll(band => germanExpSpec.IsSatisfiedBy(band))
                .ForEach(band => band.Description());

            Console.WriteLine("================Search:UK Or ClassRock");
            var ukOrClassRockExpSpect = ukExpSpec.Or(classRockExpSpec);
            bands.FindAll(band => ukOrClassRockExpSpect.IsSatisfiedBy(band))
                .ForEach(band => band.Description());
        }

        [DisplayMethod]
        public void ReposiotryPattern()
        {
            var repository = new PersonRepository();

            //add item
            repository.AddPerson(new Person { FirstName = "a", LastName = "a" });
            repository.AddPerson(new Person { FirstName = "b", LastName = "b" });
            repository.AddPerson(new Person { FirstName = "c", LastName = "c" });
            repository.AddPerson(new Person { FirstName = "d", LastName = "d" });
            repository.GetPeople().ForEach(p => (p.FirstName + p.LastName).ToConsole());

            //update item
            repository.UpdatePerson("a", new Person { FirstName = "newa", LastName = "newa" });

            //delete item
            repository.DeletePerson("d");
            repository.GetPeople().ForEach(p => (p.FirstName + p.LastName).ToConsole());
        }

        [DisplayMethod]
        public void CacheReposiotryPattern()
        {
            var repository = new CachePersonRepository(new PersonRepository());
            //add item
            repository.AddPerson(new Person { FirstName = "a", LastName = "a" });
            repository.AddPerson(new Person { FirstName = "b", LastName = "b" });
            repository.AddPerson(new Person { FirstName = "c", LastName = "c" });
            repository.AddPerson(new Person { FirstName = "d", LastName = "d" });
            repository.GetPeople().ForEach(p => (p.FirstName + p.LastName).ToConsole());
            "============================================================".ToConsole();
            //update item
            repository.UpdatePerson("a", new Person { FirstName = "newa", LastName = "newa" });
            repository.GetPeople().ForEach(p => (p.FirstName + p.LastName).ToConsole());
            "============================================================".ToConsole();
            //delete item
            repository.DeletePerson("d");
            repository.GetPeople().ForEach(p => (p.FirstName + p.LastName).ToConsole());
        }

        [DisplayMethod]
        public void MVCPattern()
        {
            //var view = new ConcreteView(new ConcreteController(new ConcreteModel()));
        }
    }
}
