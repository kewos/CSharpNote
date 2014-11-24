﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.Xml.Linq;
using DisplayPattern.DesignPattern;
using ConsoleDisplayCommon;

namespace DisplayPattern
{
    [DisplayClassAttribue]
    public class DisplayDesignPattern : AbstractDisplayMethods
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
            bloger.Regist(new Man("男生"));
            bloger.Regist(new Woman("女生"));
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
            IWorkLine workLine = new WorkLine(new Factory());
            workLine.Execute();
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
    }
}
