//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Configuration;

//namespace ConsoleDisplay.Data.DesignPattern.SubClass
//{
//    #region event
//    public class MorningEventArgs : EventArgs
//    {
//        public IPeopleState State { get; set; }

//        public MorningEventArgs(IPeopleState state)
//        {
//            State = state;
//        }
//    }

//    public class AfternoonEventArgs : EventArgs
//    {
//        public IPeopleState State { get; set; }

//        public AfternoonEventArgs(IPeopleState state)
//        {
//            State = state;
//        }
//    }

//    public class NightEventArgs : EventArgs
//    {
//        public IPeopleState State { get; set; }

//        public NightEventArgs(IPeopleState state)
//        {
//            State = state;
//        }
//    }

//    public delegate void WorkDelegate<T>(T e);

//    public interface IWorkEvents
//    {
//        WorkDelegate<MorningEventArgs> WorkAtMoning { get; set; }
//        WorkDelegate<AfternoonEventArgs> WorkAtAfternoon { get; set; }
//        WorkDelegate<NightEventArgs> WorkAtNight { get; set; }
//    }

//    public class WorkEvents : IWorkEvents
//    {
//        public WorkDelegate<MorningEventArgs> WorkAtMoning { get; set; }
//        public WorkDelegate<AfternoonEventArgs> WorkAtAfternoon { get; set; }
//        public WorkDelegate<NightEventArgs> WorkAtNight { get; set; }
//    }
//    #endregion

//    #region Factory
//    public interface IFactory
//    {
//        IPeopleState GetPeopleState();
//        IWorkEvents GetWorkEvents();
//    }

//    public class Factory : IFactory
//    {
//        IWorkEvents events;
//        IPeopleState peopleState = null;

//        public Factory()
//        {
//            PeopleWorkfigurationSection config = ConfigurationManager.GetSection("peopleWork") as PeopleWorkfigurationSection;

//            if (config != null)
//            {
//                peopleState = Activator.CreateInstance(Type.GetType(config.PeopleState.Type)) as IPeopleState;
//                peopleState.Job = config.PeopleState.Job;
//                peopleState.Energy = Convert.ToInt32(config.PeopleState.Energy);

//                events = new WorkEvents();

//                foreach (ProviderSettings module in config.Modules)
//                {
//                    IWorkModule work = Activator.CreateInstance(Type.GetType(module.Type)) as IWorkModule;
//                    work.Initialize(events);
//                }
//            }
//        }

//        public IPeopleState GetPeopleState()
//        {
//            return peopleState;
//        }

//        public IWorkEvents GetWorkEvents()
//        {
//            return events;
//        }
//    }
//    #endregion

//    #region PeopleState
//    public interface IPeopleState
//    {
//        string Job { get; set; }
//        int Energy { get; set; }
//    }

//    public class PeopleState : IPeopleState
//    {
//        public string Job { get; set; }
//        public int Energy { get; set; }
//    }
//    #endregion

//    #region provider
//    public class PeopleWorkfigurationSection : ConfigurationSection
//    {
//        [ConfigurationProperty("peopleState", IsRequired = true)]
//        public PeopleStateElement PeopleState
//        {
//            get { return (PeopleStateElement)base["peopleState"]; }
//            set { base["peopleState"] = value; }
//        }

//        [ConfigurationProperty("modules", IsRequired = true)]
//        public ProviderSettingsCollection Modules
//        {
//            get { return (ProviderSettingsCollection)base["modules"]; }
//            set { base["modules"] = value; }
//        }
//    }

//    public class ProviderTypeElement : ConfigurationElement
//    {
//        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
//        public string Name
//        {
//            get { return (string)base["name"]; }
//            set { base["name"] = value; }
//        }

//        [ConfigurationProperty("type", IsRequired = true)]
//        public string Type
//        {
//            get { return (string)base["type"]; }
//            set { base["type"] = value; }
//        }
//    }

//    public class PeopleStateElement : ProviderTypeElement
//    {
//        [ConfigurationProperty("job", IsRequired = true)]
//        public string Job
//        {
//            get { return (string)base["job"]; }
//            set { base["job"] = value; }
//        }

//        [ConfigurationProperty("energy", IsRequired = true)]
//        public string Energy
//        {
//            get { return (string)base["energy"]; }
//            set { base["energy"] = value; }
//        }
//    }
//    #endregion

//    #region WorkModule
//    public interface IWorkModule
//    {
//        void Initialize(IWorkEvents events);
//    }

//    public abstract class WorkModule : IWorkModule
//    {
//        public void PeopleFeeling(int energy, string job, string time)
//        {
//            if (energy >= 100)
//            {
//                Console.WriteLine("{0}{1}工作精力充沛", job, time);
//            }
//            else if (energy >= 50)
//            {
//                Console.WriteLine("{0}{1}工作感覺開心", job, time);
//            }
//            else
//            {
//                Console.WriteLine("{0}{1}工作度日如年", job, time);
//            }
//        }

//        public abstract void Initialize(IWorkEvents events);
//    }

//    public class WorkAtMorning : WorkModule
//    {

//        public override void Initialize(IWorkEvents events)
//        {
//            events.WorkAtMoning += Excute;
//        }

//        public void Excute(MorningEventArgs e)
//        {
//            PeopleFeeling(e.State.Energy, e.State.Job, "早上");
//            e.State.Energy -= 30;
//        }
//    }

//    public class WorkAtAfternoon : WorkModule
//    {

//        public override void Initialize(IWorkEvents events)
//        {
//            events.WorkAtAfternoon += Excute;
//        }

//        public void Excute(AfternoonEventArgs e)
//        {
//            PeopleFeeling(e.State.Energy, e.State.Job, "下午");
//            e.State.Energy -= 30;
//        }
//    }

//    public class WorkAtNight : WorkModule
//    {

//        public override void Initialize(IWorkEvents events)
//        {
//            events.WorkAtNight += Excute;
//        }

//        public void Excute(NightEventArgs e)
//        {
//            PeopleFeeling(e.State.Energy, e.State.Job, "晚上");
//            e.State.Energy -= 30;
//        }
//    }
//    #endregion

//    #region WorkLine
//    interface IWorkLine
//    {

//        void Execute();
//    }

//    class WorkLine : IWorkLine
//    {
//        IWorkEvents events;
//        IPeopleState state;

//        public WorkLine(IFactory factory)
//        {
//            state = factory.GetPeopleState();
//            events = factory.GetWorkEvents();
//        }

//        public void Execute()
//        {
//            if (events.WorkAtMoning != null)
//            {
//                MorningEventArgs arg = new MorningEventArgs(state);
//                events.WorkAtMoning(arg);
//            }

//            if (events.WorkAtAfternoon != null)
//            {
//                AfternoonEventArgs arg = new AfternoonEventArgs(state);
//                events.WorkAtAfternoon(arg);
//            }

//            if (events.WorkAtNight != null)
//            {
//                NightEventArgs arg = new NightEventArgs(state);
//                events.WorkAtNight(arg);
//            }
//        }
//    }
//    #endregion
//}
