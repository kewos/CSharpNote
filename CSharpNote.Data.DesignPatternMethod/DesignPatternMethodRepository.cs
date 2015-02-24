using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extendsions;
using CSharpNote.Core.Implements;
using CSharpNote.Data.DesignPatternMethod.SubClass;
using CSharpNote.Data.DesignPatternMethod.SubClass.ChainResponsibilityPattern;
using CSharpNote.Data.DesignPatternMethod.SubClass.CompositePattern;
using CSharpNote.Data.DesignPatternMethod.SubClass.RepositoryPattern;
using CSharpNote.Data.DesignPatternMethod.SubClass.DependecyContainer;
using CSharpNote.Data.DesignPatternMethod.SubClass.FlyweightPattern;
using CSharpNote.Data.DesignPatternMethod.SubClass.MediatorPattern;
using CSharpNote.Data.DesignPatternMethod.SubClass.ObserverPattern;
using CSharpNote.Data.DesignPatternMethod.SubClass.PrototypePattern;
using CSharpNote.Data.DesignPatternMethod.SubClass.SpecificationPattern;
using CSharpNote.Data.DesignPatternMethod.SubClass.StatePattern;
using CSharpNote.Data.DesignPatternMethod.SubClass.VistorPattern;
using CSharpNote.Data.DesignPatternMethod.SubClass.AdapterPattern;
using CSharpNote.Data.DesignPatternMethod.SubClass.BridgePattern;
using CSharpNote.Data.DesignPatternMethod.SubClass.DecoratorPattern;
using CSharpNote.Data.DesignPatternMethod.SubClass.FecadePattern;
using CSharpNote.Data.DesignPatternMethod.SubClass.NullObjectPattern;
using CSharpNote.Data.DesignPatternMethod.SubClass.ProxyPattern;
using CSharpNote.Data.DesignPatternMethod.SubClass.ServiceLocatorPattern;
using CSharpNote.Data.DesignPatternMethod.SubClass.SingletonPattern;
using CSharpNote.Data.DesignPatternMethod.SubClass.ObjectPoolPattern;

namespace CSharpNote.Data.DesignPatternMethod
{
    [MarkedRepositoryAttribue]
    public class DesignPatternMethodRepository : AbstractMethodRepository
    {
        [MarkedItem]
        public void CommandPattern()
        {
            Receiver receiver = new Receiver(20, 10);
            Invoker invoker = new Invoker();

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
            BuffetDinner buffetDinner = new BuffetDinner();
            buffetDinner.Attach(new Coffee());
            buffetDinner.Attach(new Vegetable());
            buffetDinner.Attach(new Meat());

            VistorA vistorA = new VistorA();
            VistorB vistorB = new VistorB();

            buffetDinner.Accept(vistorA);
            Console.WriteLine("----------------------");
            buffetDinner.Accept(vistorB);
        }

        [MarkedItem]
        public void NullObjectPattern()
        {
            var elements = new List<ObjectBase> {new ObjectA(), new ObjectB(), new ObjectC()};
            var repository = new ObjectRespository(elements);
            repository.Find("ObjectA").GetTypeName.ToConsole();
            repository.Find("ObjectB").GetTypeName.ToConsole();
            repository.Find("ObjectC").GetTypeName.ToConsole();
            repository.Find("ObjectD").GetTypeName.ToConsole();
        }

        [MarkedItem]
        public void StatetPattern()
        {
            var context = new Context(new StateA());
            Enumerable.Range(0, 10).ForEach(n => context.Execute());
        }

        /// <summary>
        /// 模組化subclass
        /// </summary>
        [MarkedItem]
        public void PipelinePattern()
        {
            //IWorkLine workLine = new WorkLine(new Factory());
            //workLine.Execute();
        }

        /// <summary>
        /// 合成代替繼承 減少藕合
        /// </summary>
        [MarkedItem]
        public void BridgePattern()
        {
            var elements = new List<IBridgeShape>
            {
                new CircleBridgeShape(new RedBridgeColor()),
                new CircleBridgeShape(new YellowBridgeColor()),
                new TriangleBridgeShape(new RedBridgeColor()),
                new TriangleBridgeShape(new YellowBridgeColor()),
            };
            elements.ForEach(element => element.Display());
        }

        /// <summary>
        /// 觀注點切入的設計方式
        /// 常用於input validation, log等功能
        /// 可讓程式更符合close open 的設計原則
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
        /// 實作IClone透過複製來產生實體
        /// </summary>
        [MarkedItem]
        public void PrototypePattern()
        {
            ColorManager colormanager = new ColorManager();

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
            new CompositeA(new List<SubClass.CompositePattern.IComponent>
            {
                new CompositeB(new List<SubClass.CompositePattern.IComponent>
                {
                    new Leaf(),
                    new Leaf(),
                    new Leaf()
                }),
                new CompositeB(),
                new CompositeB(new List<SubClass.CompositePattern.IComponent>
                {
                    new CompositeA(),
                    new CompositeA(),
                    new CompositeA(new List<SubClass.CompositePattern.IComponent>
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
        /// DecoratorPattern
        /// 有70%以上都在讀取
        /// 讀取 跟 增刪修分開 快取三十秒更新一次
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
        /// FecadePattern 用於隱藏子系統的細節
        /// 但子系統會跟Fecade造成耦合
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
        /// Intent:
        /// The intent of this pattern is to use sharing to support a large number of objects 
        /// that have part of their internal state in common where the other part of state can 
        /// vary.
        /// </summary>
        [MarkedItem]
        public void FlyweightPattern()
        {
            var factory = new FlyweightButtonFactory();
            Enumerable.Range(1, 30)
                .Select(n => factory.GetFlyweightButton(n%3))
                .ForEach(button => button.Draw());
        }

        [MarkedItem]
        public void MediatorPattern()
        {
            Func<int, string> convertToString = (number) => ((char) (65 + number)).ToString();
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
        [MarkedItem]
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
        [MarkedItem]
        public void ChainResponsibilityPattern()
        {
            var handler = new HandlerA();
            var handlerCommand = new HandlerCommand(typeof (HandlerD));
            handler.Execute(handlerCommand);
        }

        /// <summary>
        /// convert the interface of a class into another interface
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
        /// 著重於動態擴充方法功能
        /// </summary>
        [MarkedItem]
        public void DecoratorPattern()
        {
            new DecoratorB(new DecoratorA(new ConcreteComponentA())).Operation().ToConsole();
        }

        /// <summary>
        /// ProxyServer一開始就指定指向哪個RealServer
        /// </summary>
        [MarkedItem]
        public void ProxyPattern()
        {
            new ProxyServer().DoAction().ToConsole();
        }

        /// <summary>
        /// 游歷於各系統邊界的Pattern
        /// 優點:減少耦合 
        /// 缺點:static難追蹤 難unit test
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
        /// 於單執行緒三種都產生單一實體
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
        /// 於多執行緒的情況SingletonB SingletonC有可能產生多個實體
        /// </summary>
        [MarkedItem]
        public void SingletonPatternAtMutiThread()
        {
            Action<string, Func<int>> mutiThreadCheck = (msg, func) =>
            {
                var hashcode = func();
                var list = new List<int>();
                var threads = Enumerable.Range(0, 50)
                    .Select(n =>
                    {
                        return new Thread(() =>
                        {
                            Enumerable.Range(0, 20).ForEach(m =>
                            {
                                list.Add(func());
                            });
                        });
                    }).ToList();
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
        /// 釋放物件時回到物件池提供再使用
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
            elements2.ForEach(element =>
            {
                Console.WriteLine("HashCode:{0} TempData:{1}", element.GetHashCode(), element.TempData);
            });
        }
    }
}

                      