using System.Collections.Generic;
using System.Linq;


namespace CSharpNote.Data.DesignPatternMethod.SubClass.LazyInitial
{
    public sealed class GroupItem
    {
        private static readonly Dictionary<string, GroupItem> groupItems = new Dictionary<string, GroupItem>();

        private GroupItem(string name)
        {
            Name = name;
        }

        private string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public static GroupItem GetByName(string name)
        {
            if (!groupItems.ContainsKey(name))
            {
                groupItems[name] = new GroupItem(name);
            }

            return groupItems[name];
        }

        public static IEnumerable<GroupItem> GetAll()
        {
            return groupItems.Select(item => item.Value);
        }
    }
}
