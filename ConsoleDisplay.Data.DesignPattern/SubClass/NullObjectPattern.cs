using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDisplay.Data.DesignPattern.SubClass
{
    public class PeopleBase
    {
        public virtual string Name { get { return null; } }
        public virtual string Speak { get { return null; } }
        public static NullPeople Null { get { return new NullPeople(); } }

        public class NullPeople : PeopleBase
        {
            public override string Name { get { return ""; } }
            public override string Speak { get { return ""; } }
        }
    }

    public class OldPeople : PeopleBase
    {
        public override string Name { get { return "OldPeople"; } }
        public override string Speak { get { return "OldPeople"; } }
    }

    public class YoungPeople : PeopleBase
    {
        public override string Name { get { return "YoungPeople"; } }
        public override string Speak { get { return "YoungPeople"; } }
    }

    public class PeopleRespository
    {
        public Dictionary<string, PeopleBase> allPeople = new Dictionary<string, PeopleBase>();

        public PeopleRespository()
        {
            allPeople.Add("1", new OldPeople());
            allPeople.Add("2", new OldPeople());
            allPeople.Add("3", new OldPeople());
            allPeople.Add("4", new YoungPeople());
        }

        public PeopleBase Find(string name)
        {
            if (!allPeople.ContainsKey(name))
                return PeopleBase.Null;
            return allPeople[name];
        }
    }
}
