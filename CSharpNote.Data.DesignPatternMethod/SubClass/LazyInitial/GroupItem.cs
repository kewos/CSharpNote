using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpNote.Data.DesignPatternMethod.SubClass.LazyInitial
{
    public sealed class GroupItem
    {
        private static Dictionary<string, GroupItem> GroupItems 
            = new Dictionary<string, GroupItem>();

        private GroupItem(string name)
        {
            this.Name = name;
        }

        private string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public static GroupItem GetByName(string name)
        {
            if (!GroupItems.ContainsKey(name))
            {
                GroupItems[name] = new GroupItem(name);
            }

            return GroupItems[name];
        }

        public static IEnumerable<GroupItem> GetAll()
        {
            return GroupItems.Select(item => item.Value);
        }
    }
}
