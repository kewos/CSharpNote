using System;
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extendsions;
using CSharpNote.Core.Implements;
using CSharpNote.Data.DesignPatternMethod.SubClass;
using CSharpNote.Data.DesignPatternMethod.SubClass.RepositoryPattern;
using CSharpNote.Data.DesignPatternMethod.SubClass.DependecyContainer;

namespace CSharpNote.Data.DesignPatternMethod
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

        /// <summary>
        /// 有70%以上都在讀取
        /// 讀取 跟 增刪修分開 快取三十秒更新一次
        /// </summary>
        [DisplayMethod]
        public void CacheMechanism()
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

        /// <summary>
        /// FecadePattern 用於隱藏子系統的細節
        /// 但子系統會跟Fecade造成耦合
        /// </summary>
        [DisplayMethod]
        public void FecadePattern()
        {
            var fecade =  new Fecade();
            fecade.DoSomeThing();
        }

        /// <summary>
        /// Intent:
        /// The intent of this pattern is to use sharing to support a large number of objects 
        /// that have part of their internal state in common where the other part of state can 
        /// vary.
        /// </summary>
        [DisplayMethod]
        public void FlyweightPattern()
        {
            var factory = new FlyweightButtonFactory();
            Enumerable.Range(1, 30)
                .Select(n => factory.GetFlyweightButton(n % 3))
                .ForEach(button => button.Draw());
        }

        [DisplayMethod]
        public void MediatorPattern()
        {
            Func<int, string> convertToString = (number) => ((char)(65 + number)).ToString();
            var players = Enumerable.Range(0, 5)
                .Select(n => new GamePlayer(convertToString(n)))
                .ToList<IGamePlayer>();
            var mediator = new GamePlayMediator(players);
            players.ForEach(p => p.Win(mediator));
        }


        /// <summary>
        /// 強大的Pattern 於程式初始時建立BootStraper
        /// 讓物件都依賴DependencyInjectorContainer
        /// 之後物件的設計都用依賴注入的方式減少耦合度
        /// 並且依賴注入的物件都可以借由繼承Interface的方式來產生假物件
        /// 達到可測式的程式碼的目標
        /// </summary>
        [DisplayMethod]
        public void DependencyInjectionPattern()
        {
            var container = new DependecyConainer();
            container.RegistType<IInstanceA, InstanceA>();
            container.RegistSingleton<IInstanceB, InstanceB>();
            container.RegistType<IDependencyInjectorA, DependencyInjectorA>();
            container.RegistType<IDependencyInjectorB, DependencyInjectorB>();

            "==============================================>InstanceA".ToConsole();
            Enumerable.Range(0, 5).ForEach(n => container.Resolve<IInstanceA>().Do());

            "==============================================>InstanceB".ToConsole();
            Enumerable.Range(0, 5).ForEach(n => container.Resolve<IInstanceB>().Do());
        }


        /// <summary>
        /// 結合TemplatePattern的hook 可充份模組化HandlerClass
        /// </summary>
        [DisplayMethod]
        public void ChainResponsibilityPattern()
        {
            var handler = new HandlerA();
            var handlerCommand = new HandlerCommand(typeof(HandlerD));
            handler.Execute(handlerCommand);
        }
    }
}
