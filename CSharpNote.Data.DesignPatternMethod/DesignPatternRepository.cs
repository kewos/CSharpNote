using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;
using CSharpNote.Data.DesignPattern.Implement.AbstractFactoryPattern;
using CSharpNote.Data.DesignPattern.Implement.AdapterPattern;
using CSharpNote.Data.DesignPattern.Implement.Aop;
using CSharpNote.Data.DesignPattern.Implement.BridgePattern;
using CSharpNote.Data.DesignPattern.Implement.BuilderPattern;
using CSharpNote.Data.DesignPattern.Implement.ChainResponsibilityPattern;
using CSharpNote.Data.DesignPattern.Implement.CommandPattern;
using CSharpNote.Data.DesignPattern.Implement.CompositePattern;
using CSharpNote.Data.DesignPattern.Implement.DecoratorPattern;
using CSharpNote.Data.DesignPattern.Implement.DependecyContainer;
using CSharpNote.Data.DesignPattern.Implement.FecadePattern;
using CSharpNote.Data.DesignPattern.Implement.FilterPattern;
using CSharpNote.Data.DesignPattern.Implement.FlyweightPattern;
using CSharpNote.Data.DesignPattern.Implement.IteratorPattern;
using CSharpNote.Data.DesignPattern.Implement.LazyInitial;
using CSharpNote.Data.DesignPattern.Implement.MediatorPattern;
using CSharpNote.Data.DesignPattern.Implement.MemotoPattern;
using CSharpNote.Data.DesignPattern.Implement.NullObjectPattern;
using CSharpNote.Data.DesignPattern.Implement.ObjectPoolPattern;
using CSharpNote.Data.DesignPattern.Implement.ObserverPattern;
using CSharpNote.Data.DesignPattern.Implement.PrototypePattern;
using CSharpNote.Data.DesignPattern.Implement.ProxyPattern;
using CSharpNote.Data.DesignPattern.Implement.ReactPattern;
using CSharpNote.Data.DesignPattern.Implement.RepositoryPattern;
using CSharpNote.Data.DesignPattern.Implement.ServiceLocatorPattern;
using CSharpNote.Data.DesignPattern.Implement.SingletonPattern;
using CSharpNote.Data.DesignPattern.Implement.SpecificationPattern;
using CSharpNote.Data.DesignPattern.Implement.StateMachine;
using CSharpNote.Data.DesignPattern.Implement.StatePattern;
using CSharpNote.Data.DesignPattern.Implement.StretagyPattern;
using CSharpNote.Data.DesignPattern.Implement.VistorPattern;
using IComponent = CSharpNote.Data.DesignPattern.Implement.CompositePattern.IComponent;

namespace CSharpNote.Data.DesignPattern
{
    [MarkedRepositoryAttribue]
    public class DesignPatternRepository : AbstractRepository
    {
        [MarkedItem]
        public void CommandPattern()
        {
            var receiver = new Receiver(20, 10);
            var invoker = new Invoker();

            invoker.SetCommand(new AddCommond(receiver));
            invoker.SetCommand(new SubtractCommond(receiver));
            invoker.SetCommand(new MultiplicateCommond(receiver));
            invoker.ExecuteCommand();
        }

        [MarkedItem]
        public void ObserverPattern()
        {
            var website = new WebSiteObservable();
            var clients = new List<IObserver<Rss>> {new PcObserver(), new SmartPhoneObserver()};
            clients.ForEach(client =>
            {
                using (website.Subscribe(client))
                {
                    website.Notify(new Rss {Message = "Hello"});
                }
            });
        }

        [MarkedItem]
        public void VistorPattern()
        {
            var buffetDinner = new BuffetDinner();
            buffetDinner.Attach(new Coffee());
            buffetDinner.Attach(new Vegetable());
            buffetDinner.Attach(new Meat());

            var vistorA = new VistorA();
            var vistorB = new VistorB();

            buffetDinner.Accept(vistorA);
            Console.WriteLine("----------------------");
            buffetDinner.Accept(vistorB);
        }

        [MarkedItem]
        public void NullObjectPattern()
        {
            var repository = new ObjectRespository(new List<ObjectBase>
            {
                new ObjectA(),
                new ObjectB(),
                new ObjectC()
            });

            repository.Find("ObjectA").IsNull.ToConsole("ObjectAIsNull:");
            repository.Find("ObjectB").IsNull.ToConsole("ObjectBIsNull:");
            repository.Find("ObjectC").IsNull.ToConsole("ObjectCIsNull:");
            repository.Find("ObjectD").IsNull.ToConsole("ObjectDIsNull:");

            var nullObj = ObjectBase.Null;
            nullObj.IsNull.ToConsole("NullObjectIsNull");

            (ObjectBase.Null == ObjectBase.Null).ToConsole("NullObject == NullObject");
        }

        [MarkedItem]
        public void StatetPattern()
        {
            var context = new Context(new StateA());
            Enumerable.Range(0, 10).ForEach(n => context.Execute());
        }

        /// <summary>
        ///     模組化subclass
        /// </summary>
        [MarkedItem]
        public void PipelinePattern()
        {
            //IWorkLine workLine = new WorkLine(new Factory());
            //workLine.Execute();
        }

        /// <summary>
        ///     合成代替繼承 減少藕合
        /// </summary>
        [MarkedItem]
        public void BridgePattern()
        {
            var elements = new List<IBridgeShape>
            {
                new CircleBridgeShape(new RedBridgeColor()),
                new CircleBridgeShape(new YellowBridgeColor()),
                new TriangleBridgeShape(new RedBridgeColor()),
                new TriangleBridgeShape(new YellowBridgeColor())
            };
            elements.ForEach(element => element.Display());
        }

        /// <summary>
        ///     觀注點切入的設計方式
        ///     常用於input validation, log等功能
        ///     可讓程式更符合單一責則的設計原則
        /// </summary>
        [MarkedItem]
        public void AspectOrientProgram()
        {
            AOP.Registry.Join(
                typeof (Actor).GetConstructors().First(),
                typeof (Concern).GetConstructors().First()
                );
            var actor = (IActor) AOP.Factory.Create<Actor>("");

            Console.WriteLine(actor.Name);
            Console.WriteLine(new Actor("adabcbc").Name);
        }

        /// <summary>
        ///     實作IClone透過複製來產生實體
        /// </summary>
        [MarkedItem]
        public void PrototypePattern()
        {
            var colormanager = new ColorManager();

            colormanager["red"] = new Color(255, 0, 0);
            colormanager["green"] = new Color(0, 255, 0);
            colormanager["blue"] = new Color(0, 0, 255);

            colormanager["red"].Display();
            colormanager["green"].Display();
            colormanager["blue"].Display();
        }

        [MarkedItem]
        public void CompositePattern()
        {
            new CompositeA(new List<IComponent>
            {
                new CompositeB(new List<IComponent>
                {
                    new Leaf(),
                    new Leaf(),
                    new Leaf()
                }),
                new CompositeB(),
                new CompositeB(new List<IComponent>
                {
                    new CompositeA(),
                    new CompositeA(),
                    new CompositeA(new List<IComponent>
                    {
                        new Leaf(),
                        new Leaf(),
                        new Leaf()
                    })
                })
            }).Execute();
        }

        [MarkedItem(
            "http://www.codeproject.com/Articles/670115/Specification-pattern-in-Csharp",
            "http://en.wikipedia.org/wiki/Specification_pattern#mediaviewer/File:Specification_UML_v2.png")]
        public void SpecificationPattern()
        {
            var bands = new List<Band>
            {
                new Band("AC/DC", BandKind.HardCore, Country.Australia),
                new Band("Rammstein", BandKind.IndustryMetal, Country.Gereman),
                new Band("PinkFloyd", BandKind.ClassRock, Country.Uk),
                new Band("TheVerve", BandKind.BritPop, Country.Uk),
                new Band("Nirvana", BandKind.Grunge, Country.Uk),
                new Band("Queen", BandKind.ClassRock, Country.Uk),
                new Band("SexPistals", BandKind.Punk, Country.Uk)
            };

            ISpecification<Band> ukExpSpec =
                new ExpressionSpecification<Band>(band => band.Country == Country.Uk);
            ISpecification<Band> australiaExpSpec =
                new ExpressionSpecification<Band>(band => band.Country == Country.Australia);
            ISpecification<Band> germanExpSpec =
                new ExpressionSpecification<Band>(band => band.Country == Country.Gereman);

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

        [MarkedItem]
        public void ReposiotryPattern()
        {
            var repository = new PersonRepository();

            //add item
            repository.AddPerson(new Person {FirstName = "a", LastName = "a"});
            repository.AddPerson(new Person {FirstName = "b", LastName = "b"});
            repository.AddPerson(new Person {FirstName = "c", LastName = "c"});
            repository.AddPerson(new Person {FirstName = "d", LastName = "d"});
            repository.GetPeople().ForEach(p => (p.FirstName + p.LastName).ToConsole());

            //update item
            repository.UpdatePerson("a", new Person {FirstName = "newa", LastName = "newa"});

            //delete item
            repository.DeletePerson("d");
            repository.GetPeople().ForEach(p => (p.FirstName + p.LastName).ToConsole());
        }

        /// <summary>
        ///     DecoratorPattern
        ///     有70%以上都在讀取
        ///     讀取 跟 增刪修分開 快取三十秒更新一次
        /// </summary>
        [MarkedItem]
        public void CacheMechanism()
        {
            var repository = new CachePersonRepository(new PersonRepository());
            //add item
            repository.AddPerson(new Person {FirstName = "a", LastName = "a"});
            repository.AddPerson(new Person {FirstName = "b", LastName = "b"});
            repository.AddPerson(new Person {FirstName = "c", LastName = "c"});
            repository.AddPerson(new Person {FirstName = "d", LastName = "d"});
            repository.GetPeople().ForEach(p => (p.FirstName + p.LastName).ToConsole());
            "============================================================".ToConsole();

            //update item
            repository.UpdatePerson("a", new Person {FirstName = "newa", LastName = "newa"});
            repository.GetPeople().ForEach(p => (p.FirstName + p.LastName).ToConsole());
            "============================================================".ToConsole();

            //delete item
            repository.DeletePerson("d");
            repository.GetPeople().ForEach(p => (p.FirstName + p.LastName).ToConsole());
        }

        /// <summary>
        ///     FecadePattern 用於隱藏子系統的細節
        ///     但子系統會跟Fecade造成耦合
        /// </summary>
        [MarkedItem]
        public void FecadePattern()
        {
            var fecade = new Fecade();
            fecade.MethodA().ToConsole();
            fecade.MethodB().ToConsole();
            fecade.MethodC().ToConsole();
        }

        /// <summary>
        ///     隱藏建立細節減少耦合
        /// </summary>
        [MarkedItem]
        public void AbstractFactoryPattern()
        {
            var windowsFactory = new WindowsFactory();
            var unixFactory = new UnixFactory();

            windowsFactory.CreateProductA().Display();
            windowsFactory.CreateProductB().Display();

            unixFactory.CreateProductA().Display();
            unixFactory.CreateProductB().Display();
        }

        /// <summary>
        ///     Intent:
        ///     The intent of this pattern is to use sharing to support a large number of objects
        ///     that have part of their internal state in common where the other part of state can
        ///     vary.
        /// </summary>
        [MarkedItem]
        public void FlyweightPattern()
        {
            var factory = new FlyweightFactory();
            Enumerable.Range(1, 30)
                .Select(n => factory.Get(n%3))
                .ForEach(obj => obj.Execute());
        }

        [MarkedItem]
        public void MediatorPattern()
        {
            Func<int, string> convertToString = number => ((char) (65 + number)).ToString();
            var players = Enumerable.Range(0, 5)
                .Select(n => new GamePlayer(convertToString(n)))
                .ToList<IGamePlayer>();
            var mediator = new GamePlayMediator(players);
            players.ForEach(p => p.Win(mediator));
        }

        /// <summary>
        ///     強大的Pattern 於程式初始時建立BootStraper
        ///     讓物件都依賴DependencyInjectorContainer
        ///     之後物件的設計都用依賴注入的方式減少耦合度
        ///     並且依賴注入的物件都可以借由繼承Interface的方式來產生假物件
        ///     達到可測式的程式碼的目標
        /// </summary>
        [MarkedItem]
        public void DependencyInjectionPattern()
        {
            var container = DependecyConainer.Instance;

            //註冊實體
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
        ///     結合TemplatePattern的hook 可充份模組化HandlerClass
        /// </summary>
        [MarkedItem]
        public void ChainResponsibilityPattern()
        {
            var handler = new HandlerA();
            var handlerCommand = new HandlerCommand(typeof (HandlerD));
            handler.Execute(handlerCommand);
        }

        /// <summary>
        ///     convert the interface of a class into another interface
        /// </summary>
        [MarkedItem]
        public void AdapterPattern()
        {
            new List<IAnimal>
            {
                new DogAdaptor(new Robot()),
                new CatAdaptor(new Robot()),
                new Monkey()
            }.ForEach(animal => animal.Run());
        }

        /// <summary>
        ///     著重於動態擴充方法功能
        /// </summary>
        [MarkedItem]
        public void DecoratorPattern()
        {
            new DecoratorB(new DecoratorA(new ConcreteComponentA())).Operation().ToConsole();
        }

        /// <summary>
        ///     ProxyServer一開始就指定指向哪個RealServer
        /// </summary>
        [MarkedItem]
        public void ProxyPattern()
        {
            new ProxyServer().DoAction().ToConsole();
        }

        /// <summary>
        ///     游歷於各系統邊界的Pattern
        ///     缺點:static難追蹤 難unit test
        /// </summary>
        [MarkedItem]
        public void ServiceLocatorPattern()
        {
            var serviceLocator = ServiceLocator.Instance;
            serviceLocator.RegistService<IService1>(new Service1());
            serviceLocator.RegistService<IService2>(new Service2());

            var service1 = ServiceLocator.Instance.GetService<IService1>();
            var service2 = ServiceLocator.Instance.GetService<IService2>();

            service1.GetName().ToConsole();
            service2.GetName().ToConsole();
        }

        /// <summary>
        ///     於單執行緒三種都產生單一實體
        /// </summary>
        [MarkedItem]
        public void SingletonPattern()
        {
            Action<string, Func<int>> check = (msg, func) =>
            {
                var hashcode = func();
                var list = Enumerable.Range(0, 1000)
                    .Select(n =>
                        func());
                list.All(n => n == hashcode).ToConsole(msg);
                list.Count().ToConsole();
            };

            check("CheckSingletonA", () => SingletonA.Instance().GetHashCode());
            check("CheckSingletonB", () => SingletonB.Instance().GetHashCode());
            check("CheckSingletonC", () => SingletonC.Instance().GetHashCode());
        }

        /// <summary>
        ///     於多執行緒的情況SingletonB SingletonC有可能產生多個實體
        /// </summary>
        [MarkedItem]
        public void SingletonPatternAtMutiThread()
        {
            Action<string, Func<int>> mutiThreadCheck = (msg, func) =>
            {
                var hashcode = func();
                var list = new List<int>();
                var threads = Enumerable.Range(0, 50)
                    .Select(
                        n =>
                        {
                            return new Thread(() => { Enumerable.Range(0, 20).ForEach(m => { list.Add(func()); }); });
                        })
                    .ToList();
                threads.ForEach(thread => thread.Start());
                SpinWait.SpinUntil(() => !threads.Any(thread => thread.IsAlive), 100);
                list.All(n => n == hashcode).ToConsole(msg);
                list.Count.ToConsole();
            };

            mutiThreadCheck.Invoke("SingletonACheck:", () => SingletonA.Instance().GetHashCode());
            mutiThreadCheck.Invoke("SingletonBCheck:", () => SingletonB.Instance().GetHashCode());
            mutiThreadCheck.Invoke("SingletonCCheck:", () => SingletonC.Instance().GetHashCode());
        }

        /// <summary>
        ///     釋放物件時回到物件池提供再使用
        /// </summary>
        [MarkedItem]
        public void ObjectPoolPattern()
        {
            var resouce = Enumerable.Range(1, 10).Select(n =>
            {
                var obj = Pool.GetObject();
                obj.TempData = n.ToString();
                return obj;
            });

            var elements1 = resouce.ToList();
            elements1.ForEach(element =>
            {
                Console.WriteLine("HashCode:{0} TempData:{1}", element.GetHashCode(), element.TempData);
                Pool.ReleaseObject(element);
            });

            var elements2 = resouce.ToList();
            elements2.ForEach(
                element => { Console.WriteLine("HashCode:{0} TempData:{1}", element.GetHashCode(), element.TempData); });
        }

        /// <summary>
        ///     根據不同狀態改變執行策略
        /// </summary>
        [MarkedItem]
        public void StrategyPattern()
        {
            var strategyA = StrategyFactory.Create<StrategyA>();
            var strategyB = StrategyFactory.Create<StrategyB>();

            foreach (var status in Enumerable.Range(1, 3).Select(index => string.Format("Strategy00{0}", index)))
            {
                Console.WriteLine(strategyA[status].Invoke());
                Console.WriteLine(strategyB[status].Invoke());
            }
        }

        [MarkedItem]
        public void IteratorPattern()
        {
            var bookStore = new BookStore();
            bookStore.RegistBook(Enumerable.Range(1, 10)
                .Select(x =>
                    new Book
                    {
                        Id = x,
                        Descriptioin = x.ToString()
                    }));

            var iterator = bookStore.GetIterator();
            while (iterator.HasNext())
            {
                var book = iterator.Next();
                book.Id.ToConsole();
            }
        }

        /// <summary>
        ///     獨立Filter的樣式
        /// </summary>
        [MarkedItem]
        public void FilterPattern()
        {
            var address = new List<Address>
            {
                new Address {Contry = "Taiwan", City = "kaohsiung"},
                new Address {Contry = "Japan", City = "Tokyo"},
                new Address {Contry = "Taiwan", City = "Taipei"},
                new Address {Contry = "US", City = "NewYork"},
                new Address {Contry = "UK", City = "Londom"}
            };

            var filterManger = new FilterManager<Address>();
            foreach (var taiwanAddress in filterManger.ExecuteFilter<AddressTaiwanFilter>(address))
            {
                Console.WriteLine("Contry:{0} City:{1}",
                    taiwanAddress.Contry,
                    taiwanAddress.City);
            }
        }

        /// <summary>
        ///     Reference:http://www.robertsindall.co.uk/blog/the-reactor-pattern-using-c-sharp/
        /// </summary>
        [MarkedItem]
        public void ReactPattern()
        {
            IEventHandler client1 = new MessageEventHandler(IPAddress.Parse("123.123.123.123"), 123);
            IEventHandler client2 = new MessageEventHandler(IPAddress.Parse("234.234.234.234"), 123);
            IEventHandler client3 = new MessageEventHandler(IPAddress.Parse("245.245.245.245"), 123);

            ISynchronousEventDemultiplexer synchronousEventDemultiplexer = new SynchronousEventDemultiplexer();

            var dispatcher = new Reactor(synchronousEventDemultiplexer);

            dispatcher.RegisterHandle(client1);
            dispatcher.RegisterHandle(client2);
            dispatcher.RegisterHandle(client3);

            dispatcher.HandleEvents();
        }

        [MarkedItem]
        public void LazyInitial()
        {
            GroupItem.GetByName("A").ToConsole();
            GroupItem.GetByName("B").ToConsole();
            GroupItem.GetByName("C").ToConsole();

            foreach (var fruit in GroupItem.GetAll())
            {
                fruit.ToConsole();
            }
        }

        /// <summary>
        ///     保存狀態
        /// </summary>
        [MarkedItem]
        public void MemotoPattern()
        {
            var originator = new Charactor();
            var caretaker = new Caretaker();

            originator.Atk = 1;
            originator.Hp = 100;
            originator.Weapon = "Sword";
            caretaker.SetMemento(originator.CreateMemento());

            originator.Atk = 3;
            originator.Hp = 300;
            originator.Weapon = "Sword";
            caretaker.SetMemento(originator.CreateMemento());

            originator.Atk = 2;
            originator.Hp = 200;
            originator.Weapon = "Axe";
            caretaker.SetMemento(originator.CreateMemento());

            originator.Atk = 4;
            originator.Hp = 400;
            originator.Weapon = "Bow";
            caretaker.SetMemento(originator.CreateMemento());

            foreach (var memoto in caretaker.GetAll())
            {
                originator.RestoreMemento(memoto);
                Console.WriteLine("Atk:{0} Hp:{1} Weapon:{2}", originator.Atk, originator.Hp, originator.Weapon);
            }
        }

        [MarkedItem]
        public void StateMachine()
        {
            new StateCommandHandler().Execute();
        }

        [MarkedItem]
        public void BuilderPattern()
        {
            var builder = new CarBuilder()
                .Add("Color", "Red")
                .Add("Description", "Test")
                .Add("Size", 10)
                .Add("CreateOn", DateTime.Now);

            var instance = builder.Create();
            string.Format("{0}{1}{2}{3}", instance.Color, instance.Description, instance.Size, instance.CreateOn)
                .ToConsole();

            Enumerable.Range(1, 100)
                .Select(x => builder.Create().GetHashCode())
                .Distinct()
                .Count()
                .ToConsole();
        }
    }
}