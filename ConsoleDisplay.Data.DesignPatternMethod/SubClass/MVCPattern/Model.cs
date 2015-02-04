using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDisplay.Data.DesignPatternMethod.SubClass
{
    public abstract class Model
    {
        private readonly IList<View> Views = new List<View>();

        public void Attach(View view)
        {
            Views.Add(view);
        }
        public void Detach(View view)
        {
            Views.Remove(view);
        }
        public void Notify()
        {
            foreach (View o in Views)
            {
                o.Update();
            }
        }
    }
}
