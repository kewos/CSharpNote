using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDisplay.Data.DesignPatternMethod.SubClass
{
    public abstract class View
    {
        public abstract void Update();
        private readonly Controller Controller;

        protected View(Controller controller)
        {
            Controller = controller;
        }

        public void ContextInterface()
        {
            Controller.doSomeThing();
        }
    }
}
